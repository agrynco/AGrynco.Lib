#region Usings
using System.Collections.Generic;
#endregion

namespace AGrynco.Lib.Collections.TreeRoutine
{
    public class TreeNodeListBuilder<TTreeNode>
        where TTreeNode : TreeNode<TTreeNode>, new()
    {
        #region Delegates
        public delegate void AssignEntityDelegate(TTreeNode treeNode, ITreeNodeEntity treeNodeEntity);
        #endregion

        #region Methods (public)
        public TreeNodeList<TTreeNode> Build(ITreeNodeEntity[] treeNodeEntities,
                                             AssignEntityDelegate assignEntityDelegate)
        {
            TreeNodeList<TTreeNode> result = new TreeNodeList<TTreeNode>();
            List<ITreeNodeEntity> rootTreeNodeEntities =
                TreeNodeListBuilderUtils.GetRootTreeNodeEntities(treeNodeEntities);
            foreach (ITreeNodeEntity rootTreeNodeEntity in rootTreeNodeEntities)
            {
                TTreeNode rootTreeNode = BuildTreeNode(rootTreeNodeEntity);
                result.Add(rootTreeNode);
                FillBranche(rootTreeNode, rootTreeNodeEntity, treeNodeEntities, assignEntityDelegate);
            }
            return result;
        }

        public List<ITreeNodeEntity> Build(IEnumerable<TTreeNode> rootTreeNodes)
        {
            List<ITreeNodeEntity> result = new List<ITreeNodeEntity>();
            foreach (TTreeNode rootTreeNode in rootTreeNodes)
            {
                result.Add((ITreeNodeEntity) rootTreeNode.Tag);
                AppendTreeNodeEntities(result, rootTreeNode);
            }
            return result;
        }
        #endregion

        #region Methods (private)
        private void AppendTreeNodeEntities(List<ITreeNodeEntity> destination,
                                            TTreeNode rootTreeNode)
        {
            foreach (TTreeNode childTreeNode in rootTreeNode.Nodes)
            {
                destination.Add((ITreeNodeEntity) childTreeNode.Tag);
                AppendTreeNodeEntities(destination, childTreeNode);
            }
        }

        private TTreeNode BuildTreeNode(ITreeNodeEntity treeNodeEntity)
        {
            TTreeNode result = new TTreeNode();
            result.Tag = treeNodeEntity;
            return result;
        }

        private void FillBranche(TTreeNode rootode, ITreeNodeEntity parentTreeNodEntity,
                                 ITreeNodeEntity[] treeNodeEntities,
                                 AssignEntityDelegate assignEntityDelegate)
        {
            if (assignEntityDelegate != null)
            {
                assignEntityDelegate(rootode, parentTreeNodEntity);
            }

            List<ITreeNodeEntity> childTreeNodeEntities =
                TreeNodeListBuilderUtils.GetChilTreeNodeEntities(parentTreeNodEntity,
                                                                 treeNodeEntities);
            foreach (ITreeNodeEntity childTreeNodeEntity in childTreeNodeEntities)
            {
                TTreeNode childTreeNode = BuildTreeNode(childTreeNodeEntity);
                childTreeNode.Tag = childTreeNodeEntity;

                if (assignEntityDelegate != null)
                {
                    assignEntityDelegate(childTreeNode, childTreeNodeEntity);
                }

                rootode.Nodes.Add(childTreeNode);
                FillBranche(childTreeNode, childTreeNodeEntity, treeNodeEntities, assignEntityDelegate);
            }
        }
        #endregion
    }
}
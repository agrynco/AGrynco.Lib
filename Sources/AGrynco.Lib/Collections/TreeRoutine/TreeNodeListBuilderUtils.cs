#region Usings
using System.Collections.Generic;
#endregion

namespace AGrynCo.Lib.Collections.TreeRoutine
{
    public static class TreeNodeListBuilderUtils
    {
        #region Static Methods (private)
        private static void AppendChildTreeNodeEntities(ITreeNodeEntity parentTreeNodeEntity, List<ITreeNodeEntity> result, ITreeNodeEntity[] treeNodeEntities)
        {
            List<ITreeNodeEntity> childNodes = GetChilTreeNodeEntities(parentTreeNodeEntity, treeNodeEntities);
            foreach (ITreeNodeEntity childNode in childNodes)
            {
                result.Add(childNode);
                AppendChildTreeNodeEntities(childNode, result, treeNodeEntities);
            }
        }
        #endregion

        #region Static Methods (public)
        public static List<ITreeNodeEntity> GetChilTreeNodeEntities(ITreeNodeEntity parentTreeNodeEntity, ITreeNodeEntity[] treeNodeEntities)
        {
            List<ITreeNodeEntity> result = new List<ITreeNodeEntity>();
            foreach (ITreeNodeEntity treeNodeEntity in treeNodeEntities)
            {
                if (parentTreeNodeEntity.IsTheSameIdentifier(treeNodeEntity.ParentIdentifier))
                {
                    result.Add(treeNodeEntity);
                }
            }
            return result;
        }

        public static List<ITreeNodeEntity> GetRootTreeNodeEntities(ITreeNodeEntity[] treeNodeEntities)
        {
            List<ITreeNodeEntity> result = new List<ITreeNodeEntity>();
            foreach (ITreeNodeEntity treeNodeEntity in treeNodeEntities)
            {
                if (!treeNodeEntity.HasParent)
                {
                    result.Add(treeNodeEntity);
                }
            }
            return result;
        }

        public static List<ITreeNodeEntity> ReorderTreeNodeEntities(ITreeNodeEntity[] treeNodeEntities)
        {
            List<ITreeNodeEntity> result = new List<ITreeNodeEntity>();

            List<ITreeNodeEntity> rootTreeNodeEntities = GetRootTreeNodeEntities(treeNodeEntities);
            foreach (ITreeNodeEntity rootTreeNodeEntity in rootTreeNodeEntities)
            {
                result.Add(rootTreeNodeEntity);
                AppendChildTreeNodeEntities(rootTreeNodeEntity, result, treeNodeEntities);
            }
            return result;
        }
        #endregion
    }
}
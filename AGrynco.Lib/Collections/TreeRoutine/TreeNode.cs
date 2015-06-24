#region Usings
using System.Collections.Generic;
using System.Diagnostics;
#endregion

namespace AGrynco.Lib.Collections.TreeRoutine
{
    public class TreeNode<TTypeOfTreeNode>
        where TTypeOfTreeNode : TreeNode<TTypeOfTreeNode>
    {
        #region Fields (private)
        private readonly List<TTypeOfTreeNode> _nodes;

        private TreeNode<TTypeOfTreeNode> _parent;
        private object _tag;
        #endregion

        #region Constructors
        public TreeNode()
        {
            _nodes = new List<TTypeOfTreeNode>();
        }

        public TreeNode(TTypeOfTreeNode parent)
        {
            _parent = parent;
        }
        #endregion

        #region Methods (public)
        /// <summary>
        /// Add node to collection of _parent's _nodes
        /// </summary>
        /// <param name="treenNode">Node to add</param>
        /// <returns>Added node</returns>
        public TTypeOfTreeNode Add(TTypeOfTreeNode treenNode)
        {
            _nodes.Add(treenNode);
            treenNode.Parent = this;
            return treenNode;
        }

        public void Delete(TTypeOfTreeNode treeNode)
        {
            _nodes.Remove(treeNode);
        }
        #endregion

        #region Properties (public)
        public List<TTypeOfTreeNode> Nodes
        {
            [DebuggerStepThrough]
            get { return _nodes; }
        }

        public TreeNode<TTypeOfTreeNode> Parent
        {
            [DebuggerStepThrough]
            get { return _parent; }
            [DebuggerStepThrough]
            protected set { _parent = value; }
        }

        public object Tag
        {
            [DebuggerStepThrough]
            get { return _tag; }
            [DebuggerStepThrough]
            set { _tag = value; }
        }
        #endregion
    }
}
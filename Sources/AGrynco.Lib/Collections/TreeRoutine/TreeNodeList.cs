#region Usings
using System.Collections;
using System.Collections.Generic;
#endregion

namespace AGrynco.Lib.Collections.TreeRoutine
{
    public class TreeNodeList<TTypeOfTreeNode> : IEnumerable<TTypeOfTreeNode>
        where TTypeOfTreeNode : TreeNode<TTypeOfTreeNode>
    {
        #region Fields (private)
        private readonly List<TTypeOfTreeNode> _items;
        #endregion

        #region Constructors
        public TreeNodeList()
        {
            _items = new List<TTypeOfTreeNode>();
        }
        #endregion

        #region IEnumerable<TTypeOfTreeNode> Methods
        public IEnumerator<TTypeOfTreeNode> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion

        #region Methods (public)
        public void Add(TTypeOfTreeNode treeNode)
        {
            _items.Add(treeNode);
        }

        public void AddRange(IEnumerable<TTypeOfTreeNode> treeNodes)
        {
            foreach (TTypeOfTreeNode treeNode in treeNodes)
            {
                Add(treeNode);
            }
        }
        #endregion

        #region Properties (public)
        public int Count
        {
            get { return _items.Count; }
        }

        public TTypeOfTreeNode this[int index]
        {
            get { return _items[index]; }
        }
        #endregion
    }
}
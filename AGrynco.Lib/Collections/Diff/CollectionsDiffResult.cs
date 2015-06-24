#region Usings
using System.Collections.Generic;
#endregion

namespace AGrynco.Lib.Collections.Diff
{
    public class CollectionsDiffResult<TItem>
    {
        #region Fields (private)
        private readonly List<TItem> _toAdd;
        private readonly List<TItem> _toDelete;
        #endregion

        #region Constructors
        public CollectionsDiffResult()
        {
            _toAdd = new List<TItem>();
            _toDelete = new List<TItem>();
        }
        #endregion

        #region Properties (public)
        public List<TItem> ToAdd
        {
            get { return _toAdd; }
        }

        public List<TItem> ToDelete
        {
            get { return _toDelete; }
        }
        #endregion
    }
}
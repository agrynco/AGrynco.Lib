#region Usings
using System;
#endregion

namespace AGrynCo.Lib.Collections.TreeRoutine
{
    [Serializable]
    public abstract class TreeNodeEntityBase<TTreeNodeIdentifier> : ITreeNodeEntity
    {
        #region Fields (private)
        private TTreeNodeIdentifier _identifier;
        private TTreeNodeIdentifier _parentIdentifier;
        #endregion

        #region Constructors
        protected TreeNodeEntityBase(TTreeNodeIdentifier identifier, TTreeNodeIdentifier parentIdentifier)
        {
            _identifier = identifier;
            _parentIdentifier = parentIdentifier;
        }
        #endregion

        #region ITreeNodeEntity Properties
        public abstract bool HasParent { get; }

        object ITreeNodeEntity.Identifier
        {
            get { return Identifier; }
        }

        object ITreeNodeEntity.ParentIdentifier
        {
            get { return ParentIdentifier; }
        }
        #endregion

        #region ITreeNodeEntity Methods
        bool ITreeNodeEntity.IsTheSameIdentifier(object identifier)
        {
            return IsTheSameIdentifier((TTreeNodeIdentifier) identifier);
        }
        #endregion

        #region Abstract Methods
        public abstract bool IsTheSameIdentifier(TTreeNodeIdentifier identifier);
        #endregion

        #region Properties (public)
        public TTreeNodeIdentifier Identifier
        {
            get { return _identifier; }
            set { _identifier = value; }
        }

        public TTreeNodeIdentifier ParentIdentifier
        {
            get { return _parentIdentifier; }
            set { _parentIdentifier = value; }
        }
        #endregion
    }
}
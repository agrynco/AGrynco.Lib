#region Usings
#endregion

#region Usings
#endregion

namespace AGrynco.Lib.Collections.TreeRoutine
{
    public interface ITreeNodeEntity
    {
        #region Abstract Methods
        bool IsTheSameIdentifier(object identifier);
        #endregion

        #region Properties (public)
        bool HasParent { get; }
        object Identifier { get; }
        object ParentIdentifier { get; }
        #endregion
    }
}
#region Usings
#endregion

namespace AGrynco.Lib.Collections.TreeRoutine
{
    public interface INamedTreeNodeEntity : ITreeNodeEntity
    {
        #region Properties (public)
        string FullName { get; }
        string Name { get; set; }
        #endregion
    }
}
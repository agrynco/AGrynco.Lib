#region Usings
#endregion

namespace AGrynCo.Lib.Collections.TreeRoutine
{
    public interface INamedTreeNodeEntity : ITreeNodeEntity
    {
        #region Properties (public)
        string FullName { get; }
        string Name { get; set; }
        #endregion
    }
}
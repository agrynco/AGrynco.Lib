namespace AGrynco.Lib.Data.Repository
{
    public interface IEntity
    {
        #region Properties (public)
        IMultiKey MultiKey { get; }
        #endregion
    }
}
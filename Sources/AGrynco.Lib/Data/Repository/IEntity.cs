namespace AGrynCo.Lib.Data.Repository
{
    public interface IEntity
    {
        #region Properties (public)
        IMultiKey MultiKey { get; }
        #endregion
    }
}
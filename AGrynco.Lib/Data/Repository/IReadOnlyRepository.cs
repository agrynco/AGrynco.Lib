namespace AGrynco.Lib.Data.Repository
{
    public interface IReadOnlyRepository<TEntity, TEntityIdentifier> : IRepository
        where TEntity : BaseEntity<TEntityIdentifier>, new() where TEntityIdentifier : IMultiKey, new()
    {
        #region Abstract Methods
        TEntity Read(TEntityIdentifier identifier);
        #endregion
    }
}
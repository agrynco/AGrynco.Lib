#region Usings

#endregion

namespace AGrynco.Lib.Data.DataProviders
{
    public abstract class DbScriptExecutor : IDbScriptExecutor
    {
        #region Fields (private)
        private readonly IDbScriptLoader _dbScriptLoader;
        #endregion

        #region Constructors
        public DbScriptExecutor(IDbScriptLoader dbScriptLoader)
        {
            _dbScriptLoader = dbScriptLoader;
        }
        #endregion

        #region IDbScriptExecutor Methods
        void IDbScriptExecutor.Execute()
        {
            Execute();
        }
        #endregion

        #region Abstract Methods
        protected abstract void DoEcecute(IDbScript dbScript);
        #endregion

        #region Methods (public)
        public void Execute()
        {
            IDbScript dbScript = _dbScriptLoader.Load();
            DoEcecute(dbScript);
        }
        #endregion
    }
}
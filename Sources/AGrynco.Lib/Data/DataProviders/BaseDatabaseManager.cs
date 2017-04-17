namespace AGrynCo.Lib.Data.DataProviders
{
    public abstract class BaseDatabaseManager : IDatabaseManager
    {
        private readonly IDataProvider _dataProvider;

        protected BaseDatabaseManager(string connectionString)
        {
            _dataProvider = BuildDataProvider(connectionString);
        }

        public abstract string TargetDataBaseName { get; }

        public void Drop()
        {
            string dropDbScript = BuildDropDbScript(TargetDataBaseName);

            try
            {
                _dataProvider.ExecuteBatch(dropDbScript);
            }
            finally
            {
                _dataProvider.CloseConnection();
            }
        }

        public void CleanUp()
        {
            string cleanUpDbScript = BuildCleanUpDbScript(TargetDataBaseName);

            try
            {
                _dataProvider.ExecuteBatch(cleanUpDbScript);
            }
            finally
            {
                _dataProvider.CloseConnection();
            }
        }


        protected abstract IDataProvider BuildDataProvider(string connectionString);
        protected abstract string BuildDropDbScript(string dbName);
        protected abstract string BuildCleanUpDbScript(string targetDataBaseName);
    }
}
#region Usings
using System.Data.SqlClient;
using AGrynCo.Lib.ResourcesUtils;
#endregion

namespace AGrynCo.Lib.Data.DataProviders.MsSql
{
    public class SqlDatabaseManager : BaseDatabaseManager
    {
        private SqlConnectionStringBuilder _connectionStringBuilder;

        public SqlDatabaseManager(string connectionString)
            : base(connectionString)
        {
        }

        public override string TargetDataBaseName
        {
            get { return _connectionStringBuilder.InitialCatalog; }
        }

        protected override IDataProvider BuildDataProvider(string connectionString)
        {
            _connectionStringBuilder = new SqlConnectionStringBuilder(connectionString);

            return new SqlDbDataProvider(_connectionStringBuilder.DataSource, _connectionStringBuilder.UserID,
                _connectionStringBuilder.Password);
        }

        protected override string BuildDropDbScript(string dbName)
        {
            string result = ResourceReader.ReadAsString(typeof(SqlDatabaseManager), "AGrynCo.Lib.Data.DataProviders.MsSql.SQL.DropDb.sql");

            return result.Replace("@dbName", dbName);
        }

        protected override string BuildCleanUpDbScript(string dbName)
        {
            string result = ResourceReader.ReadAsString(typeof(SqlDatabaseManager), "AGrynCo.Lib.Data.DataProviders.MsSql.SQL.CleanUpDb.sql");

            return result.Replace("@dbName", dbName);
        }
    }
}
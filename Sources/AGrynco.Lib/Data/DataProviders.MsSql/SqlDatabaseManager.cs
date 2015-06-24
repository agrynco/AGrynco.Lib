#region Usings
using System.Data.SqlClient;

using AGrynco.Lib.ResourcesUtils;
#endregion

namespace AGrynco.Lib.Data.DataProviders.MsSql
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
            string result = ResourceReader.ReadAsString(GetType(), "Lib.Data.DataProviders.MsSql.SQL.DropDb.sql");

            return result.Replace("@dbName", dbName);
        }
    }
}
#region Usings
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using AGrynCo.Lib.Data.DataProviders.Exceptions;
using AGrynCo.Lib.ResourcesUtils;
#endregion

namespace AGrynCo.Lib.Data.DataProviders.MsSql
{
    public class SqlDbDataProvider : BaseDataProvider<SqlConnection, SqlConnectionStringBuilder>
    {
        #region Methods (private)
        private void ExecuteSqlBuilder(StringBuilder sqlStatementBuilder, int commandTimeOut)
        {
            string sqlStatement = sqlStatementBuilder.ToString().Trim();
            if (!string.IsNullOrEmpty(sqlStatement))
            {
                ExecuteNonQuery(sqlStatement, commandTimeOut);
            }
        }
        #endregion

        #region Constructors
        public SqlDbDataProvider(string connectionString)
            : base(connectionString)
        {
        }

        public SqlDbDataProvider(string hostName, string userName, string userPassword)
            : base(hostName, userName, userPassword)
        {
        }
        #endregion

        #region Properties (public)
        public SqlDbDataProvider(string hostName, string userName, string userPassword, uint defaultCommandTimeout)
            : base(hostName, userName, userPassword, defaultCommandTimeout)
        {
        }

        public override string SchemaName
        {
            get { return DbConnectionStringBuilder.DataSource; }
        }
        #endregion

        #region Methods (public)
        public override bool CheckOnDbExists()
        {
            try
            {
                OpenConnection();
                CloseConnection();
                return true;
            }
            catch (SqlException ex)
            {
                if (ex.ErrorCode == -2146232060)
                {
                    return false;
                }

                throw;
            }
        }

        public override IDbDataParameter CreateDataParameter()
        {
            return new SqlParameter();
        }

        public override void ExecuteBatch(string batchSql, int commandTimeOut)
        {
            const string SQL_SEPARATOR = "GO";

            string prearedBatchSql = batchSql;

            string[] strings = prearedBatchSql.Split(new[] {Environment.NewLine}, StringSplitOptions.None);

            StringBuilder sqlStatementBuilder = new StringBuilder();
            try
            {
                foreach (string s in strings)
                {
                    if (s.Trim().ToUpper() != SQL_SEPARATOR)
                    {
                        sqlStatementBuilder.Append(s).Append(Environment.NewLine);
                    }
                    else
                    {
                        ExecuteSqlBuilder(sqlStatementBuilder, commandTimeOut);
                        sqlStatementBuilder.Length = 0;
                    }
                }
                ExecuteSqlBuilder(sqlStatementBuilder, commandTimeOut);
            }
            catch (Exception e)
            {
                throw new ExecuteBatchException(string.Format("Error during execution '{0}'", sqlStatementBuilder), e);
            }
        }

        public override string[] GetDataBases()
        {
            string currentDbName = Connection.Database;
            SwitchToDataBase("master");
            IDbDataReader dbDataReader = ExecuteReader("SELECT name FROM master..sysdatabases");
            try
            {
                List<string> result = new List<string>();
                while (dbDataReader.Read())
                {
                    result.Add(dbDataReader["name"].ToString());
                }

                return result.ToArray();
            }
            finally
            {
                dbDataReader.Close();
                SwitchToDataBase(currentDbName);
            }
        }

        public override IDbDataReader GetRandomRow(string sql, string keyColumn)
        {
            string getCountSql = string.Format("SELECT COUNT(*) FROM ({0}) T", sql);
            int count = ExecuteScalar<int>(getCountSql, CommandType.Text);

            Random random = new Random();
            int rowNumber = random.Next(1, count);

            string sqlStatement = string.Format("SELECT * FROM (SELECT *, ROW_NUMBER() OVER (ORDER BY {1}) AS [Row] FROM ({0}) T) T2 WHERE [Row] = {2}", sql, keyColumn, rowNumber);

            return ExecuteReader(sqlStatement);
        }

        public override void KillAllConnections(string dbName)
        {
            string killConnectionScript = ResourceReader.ReadAsString(GetType(), "AGrynCo.Lib.Data.DataProviders.SQL.MsSqlKillConnections.sql");
            killConnectionScript = killConnectionScript.Replace("_DB_NAME_", dbName);
            ExecuteNonQuery(killConnectionScript);
        }

        public void UpdateStatistics()
        {
            ExecuteNonQuery("sp_updatestats", CommandType.StoredProcedure, 300000);
        }
        #endregion

        #region Methods (protected)
        protected override DbDataAdapter CreateAdapter(IDbCommand dbCommand)
        {
            return new SqlDataAdapter((SqlCommand) dbCommand);
        }

        protected override IDbCommand CreateCommand()
        {
            return new SqlCommand();
        }

        protected override SqlConnection CreateConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }

        protected override string CreateConnectionString(string dataSource, string userName, string userPassword, uint defaultCommandTimeout)
        {
            return string.Format("Data Source={0}; Persist Security Info=True; User ID={1};Password={2}; MultipleActiveResultSets=True", dataSource, userName, userPassword);
        }

        protected override SqlConnectionStringBuilder CreateDbConnectionStringBuilder(string connectionString)
        {
            return new SqlConnectionStringBuilder(connectionString);
        }

        protected override string GenerateSelectValue(string tableName, string keyName)
        {
            return string.Format("SELECT [{0}] FROM [{1}]", keyName, tableName);
        }

        protected override string GenerateSelectValueCommandText(string tableName, string sourceColumnName, string keyName)
        {
            return string.Format("SELECT [{0}] FROM [{1}] WHERE [{2}] = @{2}", sourceColumnName, tableName, keyName);
        }

        protected override string GenerateUpdateCommandText(string tableName, string targetColumnName, string keyName)
        {
            return string.Format("UPDATE [{0}] SET [{1}] = @{1} WHERE [{2}] = @{2}", tableName, targetColumnName, keyName);
        }

        protected override SqlConnection RebuildConnectionForDataBase(string dbName)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = CreateDbConnectionStringBuilder(Connection.ConnectionString);
            sqlConnectionStringBuilder.InitialCatalog = dbName;
            return CreateConnection(sqlConnectionStringBuilder.ConnectionString);
        }
        #endregion
    }
}
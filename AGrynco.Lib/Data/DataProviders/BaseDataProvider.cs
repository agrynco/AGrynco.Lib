#region Usings
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

using AGrynco.Lib.Collections;
using AGrynco.Lib.Data.DataProviders.Attributes;
using AGrynco.Lib.Data.DataProviders.Exceptions;
using AGrynco.Lib.RandomGenerators;
#endregion

namespace AGrynco.Lib.Data.DataProviders
{

    #region Usings
    #endregion

    public abstract class BaseDataProvider<TConnection, TDbConnectionStringBuilder> : IDataProvider
        where TConnection : IDbConnection where TDbConnectionStringBuilder : DbConnectionStringBuilder
    {
        #region Constants
        private const int _DEFAULT_COMMAND_TIME_OUT = 30;
        #endregion

        #region Properties (protected)
        protected DbTransaction Transaction { get; set; }
        #endregion

        #region Static Methods (protected)
        protected static void AddParameters(IDbCommand command, IDbDataParameter[] dbParameters)
        {
            if (dbParameters != null)
            {
                foreach (IDbDataParameter parameter in dbParameters)
                {
                    command.Parameters.Add(parameter);
                }
            }
        }
        #endregion

        #region Methods (public)
        public IDbDataParameter CreateDataParameter(string name, ParameterDirection direction, DbType dbType)
        {
            IDbDataParameter dbParameter = CreateDataParameter(name, direction);
            dbParameter.DbType = dbType;
            return dbParameter;
        }
        #endregion

        #region Fields (private)
        #endregion

        #region Constructors
        protected BaseDataProvider(string connectionString)
        {
            Initialize(connectionString);
        }

        protected BaseDataProvider(string hostName, string userName, string userPassword)
            : this(hostName, userName, userPassword, _DEFAULT_COMMAND_TIME_OUT)
        {
        }

        protected BaseDataProvider(string hostName, string userName, string userPassword, uint defaultCommandTimeout)
        {
            string connectionString = CreateConnectionString(hostName, userName, userPassword, defaultCommandTimeout);
            Initialize(connectionString);
        }
        #endregion

        #region IDataProvider Properties
        IDbConnection IDataProvider.Connection
        {
            get
            {
                return Connection;
            }
        }

        public bool IsInTransaction { [DebuggerStepThrough] get; private set; }

        public abstract string SchemaName { get; }
        #endregion

        #region IDataProvider Methods
        public void BeginTransaction()
        {
            OpenConnection();
            Transaction = (DbTransaction)Connection.BeginTransaction();
            IsInTransaction = true;
        }

        public abstract bool CheckOnDbExists();

        public void CloseConnection()
        {
            if (Connection.State != ConnectionState.Closed)
            {
                Connection.Close();
            }
        }

        public void Commit()
        {
            try
            {
                if (Transaction != null)
                {
                    Transaction.Commit();
                    Transaction.Dispose();
                    Transaction = null;
                }
            }
            finally
            {
                IsInTransaction = false;
            }
        }

        public abstract IDbDataParameter CreateDataParameter();

        public IDbDataParameter CreateDataParameter(string name, ParameterDirection direction)
        {
            IDbDataParameter dbParameter = CreateDataParameter();
            dbParameter.ParameterName = name;
            dbParameter.Direction = direction;
            return dbParameter;
        }

        public IDbDataParameter CreateDataParameter(string name, DbType dbType, object value)
        {
            IDbDataParameter result = CreateDataParameter(name, value);
            result.DbType = dbType;

            return result;
        }

        public IDbDataParameter CreateDataParameter(string name, DbType dbType, object value, ParameterDirection direction)
        {
            IDbDataParameter result = CreateDataParameter(name, dbType, value);
            result.Direction = direction;

            return result;
        }

        public IDbDataParameter CreateDataParameter(string name, DbType dbType, ParameterDirection direction)
        {
            IDbDataParameter result = CreateDataParameter(name, dbType);
            result.Direction = direction;

            return result;
        }

        public IDbDataParameter CreateDataParameter<T>(string name, T value)
        {
            return CreateDataParameter(name, (object)value);
        }

        public IDbDataParameter CreateDataParameter<T>(string name, T value, ParameterDirection direction)
        {
            return CreateDataParameter(name, (object)value, direction);
        }

        public IDbDataParameter CreateDataParameter(string name, object value)
        {
            IDbDataParameter dbParameter = CreateDataParameter();
            dbParameter.ParameterName = name;
            dbParameter.Value = value ?? DBNull.Value;
            return dbParameter;
        }

        public IDbDataParameter CreateDataParameter(string name, object value, ParameterDirection direction)
        {
            IDbDataParameter dbParameter = CreateDataParameter(name, value);
            dbParameter.Direction = direction;
            return dbParameter;
        }

        public IEnumerable<IDbDataParameter> CreateInsertParameters(object source)
        {
            return CreateInsertParameters(source, null);
        }

        public IEnumerable<IDbDataParameter> CreateInsertParameters(object source, Func<string, string> buildParamNameFunction)
        {
            return CreateDataParameters(source, buildParamNameFunction, typeof(InsertIgnoreAttribute));
        }

        public IEnumerable<IDbDataParameter> CreateUpdateParameters(object source)
        {
            return CreateUpdateParameters(source, null);
        }

        public IEnumerable<IDbDataParameter> CreateUpdateParameters(object source, Func<string, string> buildParamNameFunction)
        {
            return CreateDataParameters(source, buildParamNameFunction, typeof(UpdateIgnoreAttribute));
        }

        public void Dispose()
        {
            if (IsInTransaction)
            {
                RollBack();
                CloseConnection();
            }
        }

        public void ExecuteBatch(string batchSql)
        {
            ExecuteBatch(batchSql, _DEFAULT_COMMAND_TIME_OUT);
        }

        public abstract void ExecuteBatch(string batchSql, int commandTimeOut);

        public DataSet ExecuteDataSet(string sql, CommandType commandType, IDbDataParameter[] dbParamaters)
        {
            OpenConnection();
            IDbCommand command = CreateCommand(sql, commandType);
            AddParameters(command, dbParamaters);
            DbDataAdapter dataAdapter = CreateAdapter(command);
            var dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            return dataSet;
        }

        public TEntity ExecuteEntity<TEntity>(string sql) where TEntity : new()
        {
            return ExecuteEntity<TEntity>(sql, CommandType.Text);
        }

        public TEntity ExecuteEntity<TEntity>(string sql,
                                              CommandType commandType,
                                              IDbDataParameter[] dbParamaters,
                                              Action<TEntity, IDbDataReader> customMapper,
                                              Action<TEntity, IDbDataReader> additionalMapper) where TEntity : new()
        {
            return ExecuteSelect(sql, commandType, dbParamaters, customMapper, additionalMapper).SingleOrDefault();
        }

        public TEntity ExecuteEntity<TEntity>(string sql, CommandType commandType, IDbDataParameter[] dbParamaters) where TEntity : new()
        {
            return ExecuteEntity<TEntity>(sql, commandType, dbParamaters, null, null);
        }

        public TEntity ExecuteEntity<TEntity>(string sql, CommandType commandType) where TEntity : new()
        {
            return ExecuteEntity<TEntity>(sql, commandType, null, null, null);
        }

        public int ExecuteNonQuery(string sql, CommandType commandType)
        {
            return ExecuteNonQuery(sql, commandType, null);
        }

        public int ExecuteNonQuery(string sql, CommandType commandType, int commandTimeOut)
        {
            OpenConnection();

            using (IDbCommand dbCommand = CreateCommand(sql))
            {
                dbCommand.CommandTimeout = commandTimeOut;
                dbCommand.Connection = Connection;

                return dbCommand.ExecuteNonQuery();
            }
        }

        public int ExecuteNonQuery(string sql, IDbDataParameter[] dbParameters)
        {
            return ExecuteNonQuery(sql, CommandType.Text, dbParameters);
        }

        public int ExecuteNonQuery(string sql)
        {
            return ExecuteNonQuery(sql, _DEFAULT_COMMAND_TIME_OUT);
        }

        public int ExecuteNonQuery(string sql, int commandTimeOut)
        {
            return ExecuteNonQuery(sql, CommandType.Text, commandTimeOut);
        }

        public int ExecuteNonQuery(string sql, CommandType commandType, IDbDataParameter[] dbParamaters)
        {
            using (IDbCommand command = CreateCommand(sql, commandType))
            {
                command.Connection = Connection;
                AddParameters(command, dbParamaters);
                OpenConnection();
                return command.ExecuteNonQuery();
            }
        }

        public IDbDataReader ExecuteReader(string sql)
        {
            return ExecuteReader(sql, CommandType.Text, null, _DEFAULT_COMMAND_TIME_OUT);
        }

        public IDbDataReader ExecuteReader(string sql, int commandTimeOut)
        {
            return ExecuteReader(sql, CommandType.Text, _DEFAULT_COMMAND_TIME_OUT);
        }

        public IDbDataReader ExecuteReader(string sql, CommandType commandType)
        {
            return ExecuteReader(sql, commandType, null);
        }

        public IDbDataReader ExecuteReader(string sql, CommandType commandType, int commandTimeOut)
        {
            return ExecuteReader(sql, commandType, null, commandTimeOut);
        }

        public IDbDataReader ExecuteReader(string sql, CommandType commandType, IDbDataParameter[] dbParamaters)
        {
            return ExecuteReader(sql, commandType, dbParamaters, _DEFAULT_COMMAND_TIME_OUT);
        }

        public IDbDataReader ExecuteReader(string sql, CommandType commandType, IDbDataParameter[] dbParamaters, int commandTimeOut)
        {
            using (IDbCommand command = CreateCommand(sql, commandType))
            {
                command.CommandTimeout = commandTimeOut;
                AddParameters(command, dbParamaters);
                OpenConnection();
                long currentTicks = DateTime.Now.Ticks;
                try
                {
                    return new DbDataReader(command.ExecuteReader());
                }
                catch (Exception ex)
                {
                    TimeSpan duration = new TimeSpan(DateTime.Now.Ticks - currentTicks);
                    throw new DataProviderException(string.Format("Error during execute SQL (Duration = {0}) {1}", duration, sql), ex);
                }
            }
        }

        public object ExecuteScalar(string sql, CommandType commandType)
        {
            return ExecuteScalar<object>(sql, commandType, null);
        }

        public TResult ExecuteScalar<TResult>(string sql, CommandType commandType, IDbDataParameter[] dbParamaters)
        {
            return ExecuteScalar<TResult>(sql, commandType, dbParamaters, _DEFAULT_COMMAND_TIME_OUT);
        }

        public TResult ExecuteScalar<TResult>(string sql, CommandType commandType, IDbDataParameter[] dbParamaters, int commandTimeOut)
        {
            using (IDbCommand command = CreateCommand(sql, commandType))
            {
                command.CommandTimeout = commandTimeOut;

                AddParameters(command, dbParamaters);
                OpenConnection();

                object executeScalar = command.ExecuteScalar();

                return executeScalar != DBNull.Value ? TypeUtil.Cast<TResult>(executeScalar) : default(TResult);
            }
        }

        public TResult ExecuteScalar<TResult>(string sql, CommandType commandType)
        {
            return ExecuteScalar<TResult>(sql, commandType, null, _DEFAULT_COMMAND_TIME_OUT);
        }

        public DataTable ExecuteSelect(string sql)
        {
            return ExecuteSelect(sql, CommandType.Text);
        }

        public DataTable ExecuteSelect(string sql, CommandType commandType)
        {
            DataSet dataSet = ExecuteDataSet(sql, commandType, null);
            if (dataSet.Tables.Count == 0)
            {
                return null;
            }
            return dataSet.Tables[0];
        }

        public DataTable ExecuteSelect(string sql, CommandType commandType, IDbDataParameter[] dbParamaters)
        {
            DataSet dataSet = ExecuteDataSet(sql, commandType, dbParamaters);
            if (dataSet.Tables.Count == 0)
            {
                return null;
            }
            return dataSet.Tables[0];
        }

        public IEnumerable<TEntity> ExecuteSelect<TEntity>(string sql,
                                                           CommandType commandType,
                                                           IDbDataParameter[] dbParamaters,
                                                           Action<TEntity, IDbDataReader> customMapper,
                                                           Action<TEntity, IDbDataReader> additionalMapper,
                                                           int timeOut) where TEntity : new()
        {
            using (IDbDataReader reader = ExecuteReader(sql, commandType, dbParamaters, timeOut))
            {
                List<TEntity> result = new List<TEntity>();
                while (reader.Read())
                {
                    TEntity entity = new TEntity();

                    if (customMapper == null)
                    {
                        reader.Populate(entity);
                        if (additionalMapper != null)
                        {
                            additionalMapper(entity, reader);
                        }
                    }
                    else
                    {
                        customMapper(entity, reader);
                    }

                    result.Add(entity);
                }

                return result;
            }
        }

        public IEnumerable<TEntity> ExecuteSelect<TEntity>(string sql,
                                                           CommandType commandType,
                                                           IDbDataParameter[] dbParamaters,
                                                           Action<TEntity, IDbDataReader> customMapper,
                                                           Action<TEntity, IDbDataReader> additionalMapper) where TEntity : new()
        {
            return ExecuteSelect(sql, commandType, dbParamaters, customMapper, additionalMapper, _DEFAULT_COMMAND_TIME_OUT);
        }

        public IEnumerable<TEntity> ExecuteSelect<TEntity>(string sql, CommandType commandType, IDbDataParameter[] dbParamaters) where TEntity : new()
        {
            return ExecuteSelect<TEntity>(sql, commandType, dbParamaters, null);
        }

        public IEnumerable<TEntity> ExecuteSelect<TEntity>(string sql, CommandType commandType, Action<TEntity, IDbDataReader> customMapper) where TEntity : new()
        {
            return ExecuteSelect(sql, commandType, null, customMapper);
        }

        public IEnumerable<TEntity> ExecuteSelect<TEntity>(string sql, Action<TEntity, IDbDataReader> customMapper) where TEntity : new()
        {
            return ExecuteSelect(sql, CommandType.Text, customMapper);
        }

        public IEnumerable<TEntity> ExecuteSelect<TEntity>(string sql) where TEntity : new()
        {
            return ExecuteSelect<TEntity>(sql, CommandType.Text, null, null, null);
        }

        public IEnumerable<TEntity> ExecuteSelect<TEntity>(string sql, CommandType commandType, IDbDataParameter[] dbParamaters, Action<TEntity, IDbDataReader> customMapper) where TEntity : new()
        {
            return ExecuteSelect(sql, commandType, dbParamaters, customMapper, null);
        }

        public int GetCount(string tableName)
        {
            using (IDbCommand command = CreateCommand(string.Format("select COUNT(*) from {0}", tableName)))
            {
                command.Connection = Connection;
                OpenConnection();
                return (int)command.ExecuteScalar();
            }
        }

        public abstract string[] GetDataBases();

        public abstract IDbDataReader GetRandomRow(string sql, string keyColumn);

        public object GetRandomValue(string sql, string keyColumn)
        {
            return GetRandomValue(sql, keyColumn, keyColumn);
        }

        public TResult GetRandomValue<TResult>(string sql, string keyColumn)
        {
            return GetRandomValue<TResult>(sql, keyColumn, keyColumn);
        }

        public object GetRandomValue(string sql, string keyColumn, string columnNameGetValueFrom)
        {
            using (IDbDataReader reader = GetRandomRow(sql, keyColumn))
            {
                if (reader.Read())
                {
                    return reader[columnNameGetValueFrom];
                }

                throw new NoRecordsException();
            }
        }

        public TResult GetRandomValue<TResult>(string sql, string keyColumn, string columnNameGetValueFrom)
        {
            return TypeUtil.Cast<TResult>(GetRandomValue(sql, keyColumn, columnNameGetValueFrom));
        }

        public abstract void KillAllConnections(string dbName);

        public void RandomizeColumn(string tableName, string keyName, string columnToRandomizeName, bool allowNull)
        {
            ArrayList keys = GetKeys(tableName, keyName);

            Type typeOfValue = GetValue(tableName, keyName, columnToRandomizeName, CollectionUtils.GetFirst<object>(keys)).GetType();

            foreach (object key in keys)
            {
                object newValue = RandomGenerator.Instance.Generate(typeOfValue);

                ExecuteNonQuery(
                                GenerateUpdateCommandText(tableName, columnToRandomizeName, keyName),
                                CommandType.Text,
                                new[] { CreateDataParameter(keyName, key), CreateDataParameter(columnToRandomizeName, newValue) });
            }
        }

        public void RollBack()
        {
            try
            {
                if (Transaction != null)
                {
                    Transaction.Rollback();
                    Transaction.Dispose();
                    Transaction = null;
                }
            }
            finally
            {
                IsInTransaction = false;
            }
        }

        public void SwitchToDataBase(string dbName)
        {
            CloseConnection();
            Connection = RebuildConnectionForDataBase(dbName);
        }

        object IDataProvider.ExecuteScalar(string sql, CommandType commandType, IDbDataParameter[] dbParamaters)
        {
            return ExecuteScalar<object>(sql, commandType, dbParamaters);
        }
        #endregion

        #region Abstract Methods
        protected abstract DbDataAdapter CreateAdapter(IDbCommand dbCommand);

        protected abstract IDbCommand CreateCommand();

        protected abstract TConnection CreateConnection(string connectionString);

        protected abstract string CreateConnectionString(string dataSource, string userName, string userPassword, uint defaultCommandTimeout);

        protected abstract TDbConnectionStringBuilder CreateDbConnectionStringBuilder(string connectionString);

        protected abstract string GenerateSelectValue(string tableName, string keyName);

        protected abstract string GenerateSelectValueCommandText(string tableName, string sourceColumnName, string keyName);

        protected abstract string GenerateUpdateCommandText(string tableName, string targetColumnName, string keyName);

        protected abstract TConnection RebuildConnectionForDataBase(string dbName);
        #endregion

        #region Methods (private)
        private IEnumerable<IDbDataParameter> CreateDataParameters(object source, Func<string, string> buildParamNameFunction, Type ignoreAttribute)
        {
            PropertyInfo[] propertyInfos = source.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public).Where(x => x.GetCustomAttribute(ignoreAttribute) == null).ToArray();
            return propertyInfos.Select(x => CreateDataParameter(buildParamNameFunction == null ? x.Name : buildParamNameFunction(x.Name), x.GetValue(source)));
        }

        private ArrayList GetKeys(string tableName, string keyName)
        {
            string getKysSqlStatement = GenerateSelectValue(tableName, keyName);
            ArrayList keys = new ArrayList();

            using (IDbDataReader dbDataReader = ExecuteReader(getKysSqlStatement))
            {
                while (dbDataReader.Read())
                {
                    keys.Add(dbDataReader.GetValue(0));
                }
            }

            return keys;
        }

        private object GetValue(string tableName, string keyName, string columnToRandomizeName, object key)
        {
            return ((IDataProvider)this).ExecuteScalar(GenerateSelectValueCommandText(tableName, columnToRandomizeName, keyName), CommandType.Text, new[] { CreateDataParameter(keyName, key) });
        }

        private void Initialize(string connectionString)
        {
            Connection = CreateConnection(connectionString);
            DbConnectionStringBuilder = CreateDbConnectionStringBuilder(connectionString);
        }
        #endregion

        #region Methods (protected)
        protected IDbCommand CreateCommand(string sql)
        {
            return CreateCommand(sql, CommandType.Text, _DEFAULT_COMMAND_TIME_OUT);
        }

        protected IDbCommand CreateCommand(string sql, CommandType commandType)
        {
            return CreateCommand(sql, commandType, _DEFAULT_COMMAND_TIME_OUT);
        }

        protected IDbCommand CreateCommand(string sql, CommandType commandType, int commandTimeOut)
        {
            IDbCommand command = CreateCommand();
            command.Connection = Connection;
            command.CommandText = sql;
            command.CommandType = commandType;
            command.Transaction = Transaction;
            command.CommandTimeout = commandTimeOut;
            return command;
        }

        protected void HandleException()
        {
            if (IsInTransaction)
            {
                RollBack();
            }
            CloseConnection();
        }

        protected void OpenConnection()
        {
            if (Connection.State != ConnectionState.Open)
            {
                Connection.Open();
            }
        }
        #endregion

        #region Properties (public)
        protected TConnection Connection { get; set; }

        DbConnectionStringBuilder IDataProvider.DbConnectionStringBuilder
        {
            get
            {
                return DbConnectionStringBuilder;
            }
        }

        protected TDbConnectionStringBuilder DbConnectionStringBuilder { get; private set; }
        #endregion
    }
}
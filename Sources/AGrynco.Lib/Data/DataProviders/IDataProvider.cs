#region Usings
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
#endregion

namespace AGrynCo.Lib.Data.DataProviders
{
    public interface IDataProvider : IDisposable
    {
        #region Abstract Methods
        void BeginTransaction();
        bool CheckOnDbExists();
        void CloseConnection();
        void Commit();
        DbConnectionStringBuilder DbConnectionStringBuilder { get; }
        IDbDataParameter CreateDataParameter();
        IDbDataParameter CreateDataParameter(string name, object value);
        IDbDataParameter CreateDataParameter(string name, object value, ParameterDirection direction);
        IDbDataParameter CreateDataParameter(string name, ParameterDirection direction);

        IDbDataParameter CreateDataParameter(string name, DbType dbType, object value);
        IDbDataParameter CreateDataParameter(string name, DbType dbType, object value, ParameterDirection direction);
        IDbDataParameter CreateDataParameter(string name, DbType dbType, ParameterDirection direction);

        IDbDataParameter CreateDataParameter<T>(string name, T value);
        IDbDataParameter CreateDataParameter<T>(string name, T value, ParameterDirection direction);

        IEnumerable<IDbDataParameter> CreateInsertParameters(object source);
        IEnumerable<IDbDataParameter> CreateInsertParameters(object source, Func<string, string> buildParamNameFunction);

        IEnumerable<IDbDataParameter> CreateUpdateParameters(object source);
        IEnumerable<IDbDataParameter> CreateUpdateParameters(object source, Func<string, string> buildParamNameFunction);

        void ExecuteBatch(string batchSql);

        void ExecuteBatch(string batchSql, int commandTimeOut);
        DataSet ExecuteDataSet(string sql, CommandType commandType, IDbDataParameter[] dbParamaters);

        TEntity ExecuteEntity<TEntity>(string sql, CommandType commandType, IDbDataParameter[] dbParamaters, Action<TEntity, IDbDataReader> customMapper,
            Action<TEntity, IDbDataReader> additionalMapper) where TEntity : new();

        TEntity ExecuteEntity<TEntity>(string sql, CommandType commandType, IDbDataParameter[] dbParamaters) where TEntity : new();
        TEntity ExecuteEntity<TEntity>(string sql, CommandType commandType) where TEntity : new();
        TEntity ExecuteEntity<TEntity>(string sql) where TEntity : new();

        /// <summary>
        /// <see cref="IDbCommand.ExecuteNonQuery"/>
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        int ExecuteNonQuery(string sql);

        /// <summary>
        /// <see cref="IDbCommand.ExecuteNonQuery"/>
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="commandTimeOut"></param>
        /// <returns></returns>
        int ExecuteNonQuery(string sql, int commandTimeOut);

        /// <summary>
        /// <see cref="IDbCommand.ExecuteNonQuery"/>
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="commandType"></param>
        /// <param name="dbParamaters"></param>
        /// <returns></returns>
        int ExecuteNonQuery(string sql, CommandType commandType, IDbDataParameter[] dbParamaters);

        int ExecuteNonQuery(string sql, CommandType commandType);
        int ExecuteNonQuery(string sql, CommandType commandType, int commandTimeOut);

        /// <summary>
        /// <see cref="IDbCommand.ExecuteNonQuery"/>
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="dbParameters"></param>
        /// <returns></returns>
        int ExecuteNonQuery(string sql, IDbDataParameter[] dbParameters);

        IDbDataReader ExecuteReader(string sql);
        IDbDataReader ExecuteReader(string sql, int commandTimeOut);
        IDbDataReader ExecuteReader(string sql, CommandType commandType);
        IDbDataReader ExecuteReader(string sql, CommandType commandType, int commandTimeOut);
        IDbDataReader ExecuteReader(string sql, CommandType commandType, IDbDataParameter[] dbParamaters);
        IDbDataReader ExecuteReader(string sql, CommandType commandType, IDbDataParameter[] dbParamaters, int commandTimeOut);
        object ExecuteScalar(string sql, CommandType commandType);
        object ExecuteScalar(string sql, CommandType commandType, IDbDataParameter[] dbParamaters);
        TResult ExecuteScalar<TResult>(string sql, CommandType commandType);
        TResult ExecuteScalar<TResult>(string sql, CommandType commandType, IDbDataParameter[] dbParamaters);
        TResult ExecuteScalar<TResult>(string sql, CommandType commandType, IDbDataParameter[] dbParamaters, int commandTimeOut);

        DataTable ExecuteSelect(string sql);
        DataTable ExecuteSelect(string sql, CommandType commandType);
        DataTable ExecuteSelect(string sql, CommandType commandType, IDbDataParameter[] dbParamaters);

        IEnumerable<TEntity> ExecuteSelect<TEntity>(string sql, CommandType commandType, IDbDataParameter[] dbParamaters, Action<TEntity, IDbDataReader> customMapper,
            Action<TEntity, IDbDataReader> additionalMapper, int timeOut) where TEntity : new();

        IEnumerable<TEntity> ExecuteSelect<TEntity>(string sql, CommandType commandType, IDbDataParameter[] dbParamaters, Action<TEntity, IDbDataReader> customMapper,
            Action<TEntity, IDbDataReader> additionalMapper) where TEntity : new();

        IEnumerable<TEntity> ExecuteSelect<TEntity>(string sql, CommandType commandType, IDbDataParameter[] dbParamaters, Action<TEntity, IDbDataReader> customMapper) where TEntity : new();
        IEnumerable<TEntity> ExecuteSelect<TEntity>(string sql, CommandType commandType, IDbDataParameter[] dbParamaters) where TEntity : new();
        IEnumerable<TEntity> ExecuteSelect<TEntity>(string sql, CommandType commandType, Action<TEntity, IDbDataReader> customMapper) where TEntity : new();
        IEnumerable<TEntity> ExecuteSelect<TEntity>(string sql, Action<TEntity, IDbDataReader> customMapper) where TEntity : new();
        IEnumerable<TEntity> ExecuteSelect<TEntity>(string sql) where TEntity : new();

        /// <summary>
        /// Getting count of records in table
        /// </summary>
        /// <param name="tableName">Name of table in data base</param>
        /// <returns>Count of records in table</returns>
        int GetCount(string tableName);

        string[] GetDataBases();

        IDbDataReader GetRandomRow(string sql, string keyColumn);
        object GetRandomValue(string sql, string keyColumn);
        TResult GetRandomValue<TResult>(string sql, string keyColumn);
        object GetRandomValue(string sql, string keyColumn, string columnNameGetValueFrom);
        TResult GetRandomValue<TResult>(string sql, string keyColumn, string columnNameGetValueFrom);

        void KillAllConnections(string dbName);
        void RandomizeColumn(string tableName, string keyName, string columnToRandomizeName, bool allowNull);

        void RollBack();

        void SwitchToDataBase(string dbName);
        #endregion

        #region Properties (public)
        IDbConnection Connection { get; }
        bool IsInTransaction { get; }

        string SchemaName { get; }
        #endregion
    }
}
#region Usings
using System;
using System.Data;
using System.Linq;
using System.Reflection;
using AGrynCo.Lib.Data.DataProviders.Exceptions;
#endregion

namespace AGrynCo.Lib.Data.DataProviders
{
    public class DbDataReader : IDbDataReader
    {
        #region Fields (private)
        private readonly IDataReader _dataReader;
        #endregion

        #region Constructors
        public DbDataReader(IDataReader dataReader)
        {
            if (null == dataReader)
            {
                throw new ArgumentNullException("dataReader");
            }

            _dataReader = dataReader;
        }
        #endregion

        #region Methods (protected)
        protected T Cast<T>(object o)
        {
            return TypeUtil.Cast<T>(o);
        }
        #endregion

        #region IDbDataReader Properties
        public int Depth
        {
            get
            {
                return _dataReader.Depth;
            }
        }

        public int FieldCount
        {
            get
            {
                return _dataReader.FieldCount;
            }
        }

        public bool IsClosed
        {
            get
            {
                return _dataReader.IsClosed;
            }
        }

        object IDataRecord.this[int i]
        {
            get
            {
                return _dataReader[i];
            }
        }

        object IDataRecord.this[string name]
        {
            get
            {
                return _dataReader[name];
            }
        }

        public int RecordsAffected
        {
            get
            {
                return _dataReader.RecordsAffected;
            }
        }
        #endregion

        #region IDbDataReader Methods
        public void Close()
        {
            _dataReader.Close();
        }

        public void Dispose()
        {
            _dataReader.Dispose();
        }

        public bool GetBoolean(int i)
        {
            return _dataReader.GetBoolean(i);
        }

        public byte GetByte(int i)
        {
            return _dataReader.GetByte(i);
        }

        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            return _dataReader.GetBytes(i, fieldOffset, buffer, bufferoffset, length);
        }

        public char GetChar(int i)
        {
            return _dataReader.GetChar(i);
        }

        public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            return _dataReader.GetChars(i, fieldoffset, buffer, bufferoffset, length);
        }

        public IDataReader GetData(int i)
        {
            return _dataReader.GetData(i);
        }

        public string GetDataTypeName(int i)
        {
            return _dataReader.GetDataTypeName(i);
        }

        public DateTime GetDateTime(int i)
        {
            return _dataReader.GetDateTime(i);
        }

        public decimal GetDecimal(int i)
        {
            return _dataReader.GetDecimal(i);
        }

        public double GetDouble(int i)
        {
            return _dataReader.GetDouble(i);
        }

        public Type GetFieldType(int i)
        {
            return _dataReader.GetFieldType(i);
        }

        public float GetFloat(int i)
        {
            return _dataReader.GetFloat(i);
        }

        public Guid GetGuid(int i)
        {
            return _dataReader.GetGuid(i);
        }

        public short GetInt16(int i)
        {
            return _dataReader.GetInt16(i);
        }

        public int GetInt32(int i)
        {
            return _dataReader.GetInt32(i);
        }

        public long GetInt64(int i)
        {
            return _dataReader.GetInt64(i);
        }

        public string GetName(int i)
        {
            return _dataReader.GetName(i);
        }

        public int GetOrdinal(string name)
        {
            return _dataReader.GetOrdinal(name);
        }

        public DataTable GetSchemaTable()
        {
            return _dataReader.GetSchemaTable();
        }

        public string GetString(int i)
        {
            return _dataReader.GetString(i);
        }

        public object GetValue(int i)
        {
            return _dataReader.GetValue(i);
        }

        public T GetValue<T>(string fieldName)
        {
            try
            {
                var cellValue = _dataReader[fieldName];

                return Cast<T>(cellValue);
            }
            catch (IndexOutOfRangeException ex)
            {
                //Logger.Exception(ex);
                throw new DataProviderException(string.Format("There is no field with name = \"{0}\"", fieldName), ex);
            }
        }

        public T GetValue<T>(int index)
        {
            try
            {
                var cellValue = _dataReader[index];

                return Cast<T>(cellValue);
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new DataProviderException(string.Format("There is no field with index = \"{0}\"", index), ex);
            }
        }

        public object GetValue(string fieldName)
        {
            try
            {
                return _dataReader[fieldName];
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new ThereIsNoFieldException(string.Format("There is no field with name \"{0}\"", fieldName), ex);
            }
        }

        public int GetValues(object[] values)
        {
            return _dataReader.GetValues(values);
        }

        public bool IsDBNull(int i)
        {
            return _dataReader.IsDBNull(i);
        }

        public bool NextResult()
        {
            return _dataReader.NextResult();
        }

        public void Populate<T>(T entity)
        {
            PropertyInfo[] propertyInfos =
                typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public).Where(x => x.GetCustomAttribute(typeof(CustomAttributes.IgnoreAttribute)) == null).ToArray();
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                PropertyValueManager.SetValue(entity, propertyInfo.Name, GetValue(propertyInfo.Name));
            }
        }

        public bool Read()
        {
            return _dataReader.Read();
        }
        #endregion
    }
}
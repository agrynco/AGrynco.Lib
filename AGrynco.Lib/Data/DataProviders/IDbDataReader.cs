#region Usings
using System.Data;
#endregion

namespace AGrynco.Lib.Data.DataProviders
{
    public interface IDbDataReader : IDataReader
    {
        #region Abstract Methods
        T GetValue<T>(string fieldName);
        T GetValue<T>(int index);
        void Populate<T>(T entity);
        object GetValue(string fieldName);
        #endregion
    }
}
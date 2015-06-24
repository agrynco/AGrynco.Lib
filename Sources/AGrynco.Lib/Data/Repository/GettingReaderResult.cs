#region Usings
using System;

using AGrynco.Lib.Data.DataProviders;
#endregion

namespace AGrynco.Lib.Data.Repository
{
    public class GettingReaderResult : IDisposable
    {
        #region Constructors
        public GettingReaderResult(IDbDataReader dataReader, string description)
        {
            DataReader = dataReader;
            Description = description;
        }
        #endregion

        #region Methods (public)
        public void Dispose()
        {
            DataReader.Close();
            DataReader.Dispose();
        }
        #endregion

        #region Properties (public)
        public IDbDataReader DataReader { get; private set; }
        public string Description { get; private set; }
        #endregion
    }
}
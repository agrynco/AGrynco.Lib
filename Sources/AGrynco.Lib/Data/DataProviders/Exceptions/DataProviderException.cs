#region Usings
using System;
using System.Runtime.Serialization;
#endregion

namespace AGrynCo.Lib.Data.DataProviders.Exceptions
{
    public class DataProviderException : Exception
    {
        #region Constructors
        public DataProviderException()
        {
        }

        public DataProviderException(string message) : base(message)
        {
        }

        public DataProviderException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DataProviderException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
        #endregion
    }
}
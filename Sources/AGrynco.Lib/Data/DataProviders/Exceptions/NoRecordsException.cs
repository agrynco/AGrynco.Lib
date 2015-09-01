#region Usings
using System;
using System.Runtime.Serialization;
#endregion

namespace AGrynCo.Lib.Data.DataProviders.Exceptions
{
    public class NoRecordsException : DataProviderException
    {
        #region Constructors
        public NoRecordsException()
        {
        }

        public NoRecordsException(string message) : base(message)
        {
        }

        public NoRecordsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoRecordsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
        #endregion
    }
}
#region Usings
using System;
using System.Runtime.Serialization;
#endregion

namespace AGrynCo.Lib.Data.DataProviders.Exceptions
{
    public class ExecuteBatchException : DataProviderException
    {
        #region Constructors
        public ExecuteBatchException()
        {
        }

        public ExecuteBatchException(string message)
            : base(message)
        {
        }

        public ExecuteBatchException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected ExecuteBatchException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
        #endregion
    }
}
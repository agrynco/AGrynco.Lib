using System;
using System.Runtime.Serialization;

namespace AGrynCo.Lib.Data.DataProviders.Exceptions
{
    public class ExecuteScalarException : DataProviderException
    {
        public ExecuteScalarException()
        {
        }

        public ExecuteScalarException(string message) : base(message)
        {
        }

        public ExecuteScalarException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ExecuteScalarException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
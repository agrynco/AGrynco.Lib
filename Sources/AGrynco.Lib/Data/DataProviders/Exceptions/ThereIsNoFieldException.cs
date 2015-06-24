using System;
using System.Runtime.Serialization;

namespace AGrynco.Lib.Data.DataProviders.Exceptions
{
    public class ThereIsNoFieldException : DataProviderException
    {
        public ThereIsNoFieldException()
        {
        }

        public ThereIsNoFieldException(string message) : base(message)
        {
        }

        public ThereIsNoFieldException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ThereIsNoFieldException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
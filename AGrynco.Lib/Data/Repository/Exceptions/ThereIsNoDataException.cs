using System;
using System.Runtime.Serialization;

namespace AGrynco.Lib.Data.Repository.Exceptions
{
    public class ThereIsNoDataException : RepositoryException
    {
        public ThereIsNoDataException()
        {
        }

        public ThereIsNoDataException(string message) : base(message)
        {
        }

        public ThereIsNoDataException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ThereIsNoDataException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
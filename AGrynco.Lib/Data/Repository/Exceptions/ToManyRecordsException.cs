#region Usings
using System;
using System.Runtime.Serialization;
#endregion

namespace AGrynco.Lib.Data.Repository.Exceptions
{
    public class ToManyRecordsException : RepositoryException
    {
        #region Constructors
        public ToManyRecordsException()
        {
        }

        public ToManyRecordsException(string message) : base(message)
        {
        }

        public ToManyRecordsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ToManyRecordsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
        #endregion
    }
}
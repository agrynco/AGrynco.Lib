using System;
using System.Runtime.Serialization;

namespace AGrynCo.Lib.Data.Repository.Exceptions
{
    #region Usings
    
    #endregion

    public class RepositoryException : Exception
    {
        #region Constructors
        public RepositoryException()
        {
        }

        public RepositoryException(string message)
            : base(message)
        {
        }

        public RepositoryException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected RepositoryException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
        #endregion
    }
}
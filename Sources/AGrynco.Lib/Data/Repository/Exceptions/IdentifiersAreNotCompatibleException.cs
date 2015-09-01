#region Usings

#endregion

using System;
using System.Runtime.Serialization;

namespace AGrynCo.Lib.Data.Repository.Exceptions
{
    #region Usings
    
    #endregion

    public class IdentifiersAreNotCompatibleException : RepositoryException
    {
        #region Constructors
        public IdentifiersAreNotCompatibleException()
        {
        }

        public IdentifiersAreNotCompatibleException(string message)
            : base(message)
        {
        }

        public IdentifiersAreNotCompatibleException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected IdentifiersAreNotCompatibleException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
        #endregion
    }
}
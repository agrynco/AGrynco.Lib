#region Usings

#endregion

using System;
using System.Runtime.Serialization;

namespace AGrynco.Lib.Data.Repository.Exceptions
{
    public class AreDublicateKeysException : RepositoryException
    {
        #region Constructors
        public AreDublicateKeysException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public AreDublicateKeysException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public AreDublicateKeysException(string message)
            : base(message)
        {
        }

        public AreDublicateKeysException()
        {
        }
        #endregion
    }
}
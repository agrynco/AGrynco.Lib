#region Usings
using System;
using System.Runtime.Serialization;
#endregion

namespace AGrynco.Lib.Exceptions
{
    public class DuplicateException : Exception
    {
        #region Constructors
        public DuplicateException()
        {
        }

        public DuplicateException(string message)
            : base(message)
        {
        }

        public DuplicateException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected DuplicateException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
        #endregion
    }
}
#region Usings
using System;
using System.Runtime.Serialization;
#endregion

namespace AGrynco.Lib.Exceptions
{
    public class NotDefinedException : Exception
    {
        #region Constructors
        public NotDefinedException()
        {
        }

        public NotDefinedException(string message) : base(message)
        {
        }

        public NotDefinedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotDefinedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
        #endregion
    }
}
#region Usings
using System;
using System.Runtime.Serialization;
#endregion

namespace AGrynCo.Lib.Exceptions
{
    public class NotYetDefinedException : Exception
    {
        #region Constructors
        public NotYetDefinedException()
        {
        }

        public NotYetDefinedException(string message) : base(message)
        {
        }

        public NotYetDefinedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotYetDefinedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
        #endregion
    }
}
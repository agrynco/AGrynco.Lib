#region Usings
using System;
using System.Runtime.Serialization;
#endregion

namespace AGrynCo.Lib.Exceptions
{
    public class ThereIsNoItemException : Exception
    {
        #region Constructors
        public ThereIsNoItemException()
        {
        }

        public ThereIsNoItemException(string message)
            : base(message)
        {
        }

        public ThereIsNoItemException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected ThereIsNoItemException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
        #endregion
    }
}
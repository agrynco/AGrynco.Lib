#region Usings
using System;
using System.Runtime.Serialization;
#endregion

namespace AGrynco.Lib.Exceptions
{
    public class RegularExpressionException : Exception
    {
        #region Constructors
        public RegularExpressionException()
        {
        }

        public RegularExpressionException(string message) : base(message)
        {
        }

        public RegularExpressionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RegularExpressionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
        #endregion
    }
}
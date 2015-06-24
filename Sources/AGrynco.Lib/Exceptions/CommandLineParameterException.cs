#region Usings
using System;
using System.Runtime.Serialization;
#endregion

namespace AGrynco.Lib.Exceptions
{
    public class CommandLineParameterException : Exception
    {
        #region Constructors
        public CommandLineParameterException()
        {
        }

        public CommandLineParameterException(string message)
            : base(message)
        {
        }

        public CommandLineParameterException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected CommandLineParameterException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
        #endregion
    }
}
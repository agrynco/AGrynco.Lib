#region Usings
using System;
using System.Runtime.Serialization;
#endregion

namespace AGrynco.Lib.Exceptions
{
    public class ContainerRegisterTypeException : Exception
    {
        #region Constructors
        public ContainerRegisterTypeException()
        {
        }

        public ContainerRegisterTypeException(string message) : base(message)
        {
        }

        public ContainerRegisterTypeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ContainerRegisterTypeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
        #endregion
    }
}
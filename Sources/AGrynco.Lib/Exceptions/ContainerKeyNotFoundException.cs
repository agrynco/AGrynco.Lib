#region Usings
using System;
using System.Runtime.Serialization;
#endregion

namespace AGrynco.Lib.Exceptions
{
    public class ContainerKeyNotFoundException : Exception
    {
        #region Constructors
        public ContainerKeyNotFoundException()
        {
        }

        public ContainerKeyNotFoundException(string message)
            : base(message)
        {
        }

        public ContainerKeyNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected ContainerKeyNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
        #endregion
    }
}
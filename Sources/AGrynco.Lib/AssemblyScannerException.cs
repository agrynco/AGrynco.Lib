#region Usings
using System;
using System.Runtime.Serialization;
#endregion

namespace AGrynCo.Lib
{
    public class AssemblyScannerException : Exception
    {
        public AssemblyScannerException()
        {
        }

        public AssemblyScannerException(string message)
            : base(message)
        {
        }

        public AssemblyScannerException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected AssemblyScannerException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
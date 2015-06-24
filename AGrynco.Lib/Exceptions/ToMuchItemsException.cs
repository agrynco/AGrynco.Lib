#region Usings
using System;
using System.Runtime.Serialization;
#endregion

namespace AGrynco.Lib.Exceptions
{
    public class ToMuchItemsException : Exception
    {
        #region Constructors
        public ToMuchItemsException()
        {
        }

        public ToMuchItemsException(string message)
            : base(message)
        {
        }

        public ToMuchItemsException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected ToMuchItemsException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
        #endregion
    }
}
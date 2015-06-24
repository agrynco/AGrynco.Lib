#region Usings
using System;
using System.Runtime.Serialization;
#endregion

namespace AGrynco.Lib.Exceptions
{
    public class CanNotFindControlException : Exception
    {
        #region Constructors
        public CanNotFindControlException()
        {
        }

        public CanNotFindControlException(string message)
            : base(message)
        {
        }

        public CanNotFindControlException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected CanNotFindControlException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
        #endregion
    }
}
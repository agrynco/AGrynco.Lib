#region Usings
using System;
using System.Runtime.Serialization;
#endregion

namespace AGrynco.Lib.Exceptions
{
    public class ConvertException : Exception
    {
        #region Constructors
        public ConvertException()
        {
        }

        public ConvertException(Type typeOfConverter, object value, Type destinationType)
            : this(typeOfConverter, value, destinationType, null)
        {
        }

        public ConvertException(Type typeOfConverter, object value, Type destinationType, Exception innerException)
            : this(string.Format("{0}: can not convert value {1} of type {2} to type {3}", typeOfConverter, value, value == null ? null : value.GetType(), destinationType), innerException)
        {
        }

        public ConvertException(string message)
            : base(message)
        {
        }

        public ConvertException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected ConvertException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
        #endregion
    }
}
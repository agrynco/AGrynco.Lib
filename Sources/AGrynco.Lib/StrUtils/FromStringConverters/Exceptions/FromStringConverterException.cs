#region Usings
using System;
using System.Runtime.Serialization;
using AGrynCo.Lib.Exceptions;
#endregion

namespace AGrynCo.Lib.StrUtils.FromStringConverter.Exceptions
{
    public class FromStringConvertException : ConvertException
    {
        #region Constructors
        public FromStringConvertException()
        {
        }

        public FromStringConvertException(Type typeOfConverter, object value, Type destinationType)
            : base(typeOfConverter, value, destinationType)
        {
        }

        public FromStringConvertException(Type typeOfConverter, object value, Type destinationType, Exception innerException)
            : base(typeOfConverter, value, destinationType, innerException)
        {
        }

        public FromStringConvertException(string message)
            : base(message)
        {
        }

        public FromStringConvertException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected FromStringConvertException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
        #endregion
    }
}
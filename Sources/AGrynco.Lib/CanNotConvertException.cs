#region Usings
using System;
#endregion

namespace AGrynco.Lib
{
    public class CanNotConvertException : Exception
    {
        #region Constructors
        public CanNotConvertException(Type convertedValueType, Exception innerException)
            : base(string.Format("Can not convert type \"{0}\"", convertedValueType), innerException)
        {
        }

        public CanNotConvertException(Type convertedValueType)
            : this(convertedValueType, null)
        {
        }
        #endregion
    }
}
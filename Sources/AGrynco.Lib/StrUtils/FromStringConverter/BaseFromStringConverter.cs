#region Usings
using System;

using AGrynco.Lib.Exceptions;
#endregion

namespace AGrynco.Lib.StrUtils.FromStringConverter
{
    public abstract class BaseFromStringConverter<TResult> : IFromStringConverter<TResult>
    {
        #region Abstract Methods
        protected abstract TResult DoConvert(string value);
        #endregion

        #region IFromStringConverter<TResult> Methods
        public TResult Convert(string value)
        {
            try
            {
                return DoConvert(value);
            }
            catch (Exception)
            {
                throw new ConvertException(GetType(), value, typeof(TResult));
            }
        }

        object IFromStringConverter.Convert(string value)
        {
            return Convert(value);
        }
        #endregion
    }
}
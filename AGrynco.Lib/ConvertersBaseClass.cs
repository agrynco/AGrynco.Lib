#region Usings
using System;
#endregion

namespace AGrynco.Lib
{
    public abstract class ConvertersBaseClass<TConversionResult> : IValueConverter<TConversionResult>
    {
        #region IValueConverter<TConversionResult> Properties
        public Type ConversionResultType
        {
            get
            {
                return typeof(TConversionResult);
            }
        }
        #endregion

        #region IValueConverter<TConversionResult> Methods
        public TConversionResult Convert(object value)
        {
            try
            {
                if (DBNull.Value == value || null == value)
                {
                    return default(TConversionResult);
                }

                return DoConvert(value);
            }
            catch (Exception e)
            {
                if (value != null)
                {
                    throw new CanNotConvertException(value.GetType(), e);
                }

                throw;
            }
        }
        #endregion

        #region Abstract Methods
        protected abstract TConversionResult DoConvert(object value);
        #endregion
    }
}
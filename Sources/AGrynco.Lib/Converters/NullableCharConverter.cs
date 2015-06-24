#region Usings
using System;
#endregion

namespace AGrynco.Lib.Converters
{
    [Converter]
    public class NullableCharConverter : ConvertersBaseClass<char?>
    {
        #region Methods (protected)
        protected override char? DoConvert(object value)
        {
            if (value == null || value == DBNull.Value)
            {
                return null;
            }

            if (value is string)
            {
                string s = (string)value;
                if (s.Length > 1)
                {
                    throw new CanNotConvertException(typeof(string));
                }
                else
                {
                    return s[0];
                }
            }

            throw new CanNotConvertException(value.GetType());
        }
        #endregion
    }
}
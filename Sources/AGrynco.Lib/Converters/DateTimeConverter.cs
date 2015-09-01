#region Usings
using System;
#endregion

namespace AGrynCo.Lib.Converters
{
    [Converter]
    internal class DateTimeConverter : ConvertersBaseClass<DateTime>
    {
        #region Methods (protected)
        protected override DateTime DoConvert(object value)
        {
            return System.Convert.ToDateTime(value);
        }
        #endregion
    }
}
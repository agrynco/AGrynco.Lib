#region Usings
using System;
#endregion

namespace AGrynco.Lib.Converters
{
    [Converter]
    public class NullableDateTimeConverter : ConvertersBaseClass<DateTime?>
    {
        protected override DateTime? DoConvert(object value)
        {
            return value != null ? System.Convert.ToDateTime(value) : (DateTime?)null;
        }
    }
}
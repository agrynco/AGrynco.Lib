#region Usings
using System;
#endregion

namespace AGrynCo.Lib.StrUtils.FromStringConverters
{
    [FromStringConverter]
    public class TimeSpanFromStringConverter : BaseFromStringConverter<TimeSpan>
    {
        protected override TimeSpan DoConvert(string value)
        {
            return TimeSpan.Parse(value);
        }
    }
}
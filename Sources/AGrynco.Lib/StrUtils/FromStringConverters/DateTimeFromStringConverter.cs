#region Usings
using System;
#endregion

namespace AGrynCo.Lib.StrUtils.FromStringConverters
{
    [FromStringConverter]
    public class DateTimeFromStringConverter : BaseFromStringConverter<DateTime>
    {
        #region Static Fields (public)
        public static readonly DateTimeFromStringConverter DefaultInstance = new DateTimeFromStringConverter();
        #endregion

        #region Methods (protected)
        protected override DateTime DoConvert(string value)
        {
            string strToConvert = value.Replace('/', '.');
            return DateTime.Parse(strToConvert);
        }
        #endregion
    }
}
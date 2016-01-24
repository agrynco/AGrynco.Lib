#region Usings
using System.Threading;
#endregion

namespace AGrynCo.Lib.StrUtils.FromStringConverter
{
    [FromStringConverter]
    public class DecimalFromStringConverter : BaseFromStringConverter<decimal>
    {
        #region Methods (protected)
        protected override decimal DoConvert(string value)
        {
            string currencyDecimalSeparator = Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
            return decimal.Parse(value.Replace(".", currencyDecimalSeparator).Replace(",", currencyDecimalSeparator));
        }
        #endregion
    }
}
namespace AGrynco.Lib.Converters
{
    [Converter]
    internal class DecimalConverter : ConvertersBaseClass<decimal>
    {
        #region Methods (protected)
        protected override decimal DoConvert(object value)
        {
            return System.Convert.ToDecimal(value);
        }
        #endregion
    }
}
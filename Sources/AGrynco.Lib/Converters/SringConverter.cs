namespace AGrynco.Lib.Converters
{
    [Converter]
    internal class SringConverter : ConvertersBaseClass<string>
    {
        #region Methods (protected)
        protected override string DoConvert(object value)
        {
            return System.Convert.ToString(value);
        }
        #endregion
    }
}
namespace AGrynco.Lib.Converters
{
    [Converter]
    internal class BooleanConverter : ConvertersBaseClass<bool>
    {
        #region Methods (protected)
        protected override bool DoConvert(object value)
        {
            return System.Convert.ToBoolean(value);
        }
        #endregion
    }
}
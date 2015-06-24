namespace AGrynco.Lib.Converters
{
    [Converter]
    internal class NullableIntConverter : ConvertersBaseClass<int?>
    {
        #region Methods (protected)
        protected override int? DoConvert(object value)
        {
            return System.Convert.ToInt32(value);
        }
        #endregion
    }
}
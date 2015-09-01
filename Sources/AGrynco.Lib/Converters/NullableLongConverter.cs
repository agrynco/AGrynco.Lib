namespace AGrynCo.Lib.Converters
{
    [Converter]
    internal class NullableLongConverter : ConvertersBaseClass<long?>
    {
        #region Methods (protected)
        protected override long? DoConvert(object value)
        {
            return System.Convert.ToInt64(value);
        }
        #endregion
    }
}
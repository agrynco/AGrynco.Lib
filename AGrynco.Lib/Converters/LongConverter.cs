namespace AGrynco.Lib.Converters
{
    [Converter]
    internal class LongConverter : ConvertersBaseClass<long>
    {
        #region Methods (protected)
        protected override long DoConvert(object value)
        {
            return System.Convert.ToInt64(value);
        }
        #endregion
    }
}
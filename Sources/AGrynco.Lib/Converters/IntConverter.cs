namespace AGrynCo.Lib.Converters
{
    [Converter]
    internal class IntConverter : ConvertersBaseClass<int>
    {
        #region Methods (protected)
        protected override int DoConvert(object value)
        {
            return System.Convert.ToInt32(value);
        }
        #endregion
    }
}
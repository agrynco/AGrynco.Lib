namespace AGrynCo.Lib.Converters
{
    [Converter]
    internal class UIntConverter : ConvertersBaseClass<uint>
    {
        #region Methods (protected)
        protected override uint DoConvert(object value)
        {
            return System.Convert.ToUInt32(value);
        }
        #endregion
    }
}
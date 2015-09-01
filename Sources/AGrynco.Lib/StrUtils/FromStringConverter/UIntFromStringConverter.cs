namespace AGrynCo.Lib.StrUtils.FromStringConverter
{
    [FromStringConverter]
    public class UIntFromStringConverter : BaseFromStringConverter<uint>
    {
        #region Methods (protected)
        protected override uint DoConvert(string value)
        {
            return uint.Parse(value);
        }
        #endregion
    }
}
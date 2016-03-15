namespace AGrynCo.Lib.StrUtils.FromStringConverters
{
    [FromStringConverter]
    public class NullableBooleanFromStringConverter : ToNullableFromStringConverter<bool?>
    {
        #region Methods (protected)
        protected override bool? DoConvertNotNull(string value)
        {
            return bool.Parse(value);
        }
        #endregion
    }
}
namespace AGrynCo.Lib.StrUtils.FromStringConverter
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
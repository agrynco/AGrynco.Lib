namespace AGrynCo.Lib.StrUtils.FromStringConverters
{
    [FromStringConverter]
    public class NullableIntFromStringConverter : ToNullableFromStringConverter<int?>
    {
        protected override int? DoConvertNotNull(string value)
        {
            return IntFromStringConverter.Instance.Convert(value);
        }
    }
}
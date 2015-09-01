namespace AGrynCo.Lib.StrUtils.FromStringConverter
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
namespace AGrynCo.Lib.Converters
{
    [Converter]
    public class ObjectConverter : ConvertersBaseClass<object>
    {
        protected override object DoConvert(object value)
        {
            return value;
        }
    }
}
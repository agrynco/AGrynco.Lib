namespace AGrynco.Lib.Converters
{
    [Converter]
    public class CharConverter : ConvertersBaseClass<char>
    {
        protected override char DoConvert(object value)
        {
            return System.Convert.ToChar(value);
        }
    }
}
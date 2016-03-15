namespace AGrynCo.Lib.StrUtils.FromStringConverters
{
    [FromStringConverter]
    public class BoolFromStringConverter : BaseFromStringConverter<bool>
    {
        protected override bool DoConvert(string value)
        {
            return bool.Parse(value);
        }
    }
}
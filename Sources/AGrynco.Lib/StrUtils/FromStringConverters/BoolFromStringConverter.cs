namespace AGrynCo.Lib.StrUtils.FromStringConverter
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
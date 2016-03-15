namespace AGrynCo.Lib.StrUtils.FromStringConverters
{
    public abstract class ToNullableFromStringConverter<TResult> : BaseFromStringConverter<TResult>
    {
        protected override TResult DoConvert(string value)
        {
            if (string.IsNullOrEmpty(value) || value == "null")
            {
                return default(TResult);
            }
            
            return DoConvertNotNull(value);
        }

        protected abstract TResult DoConvertNotNull(string value);
    }
}
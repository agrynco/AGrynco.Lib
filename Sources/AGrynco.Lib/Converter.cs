namespace AGrynCo.Lib
{
    public class Converter
    {
        #region Methods (public)
        public T Convert<T>(object value)
        {
            IValueConverter<T> converter = GetConverter<T>();

            return converter.Convert(value);
        }
        #endregion

        #region Methods (private)
        private IValueConverter<T> GetConverter<T>()
        {
            var converter = ConverterFactory.GetConvrter<T>();

            return converter;
        }
        #endregion
    }
}
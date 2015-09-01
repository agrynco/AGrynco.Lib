#region Usings
#endregion

#region Usings
#endregion

namespace AGrynCo.Lib.ToStringConverters
{
    public class BaseToStringConverter<T> : IParamValueToStringConverter
    {
        #region IParamValueToStringConverter Methods
        string IParamValueToStringConverter.Convert(object value)
        {
            return Convert((T)value);
        }
        #endregion

        #region Methods (public)
        public virtual string Convert(T value)
        {
            return System.Convert.ToString(value);
        }
        #endregion
    }
}
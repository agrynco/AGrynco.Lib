#region Usings
#endregion

#region Usings
#endregion

namespace AGrynco.Lib.ToStringConverters
{
    public interface IParamValueToStringConverter
    {
        #region Abstract Methods
        string Convert(object value);
        #endregion
    }
}
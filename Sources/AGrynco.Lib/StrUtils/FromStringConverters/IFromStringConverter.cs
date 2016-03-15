#region Usings
#endregion

namespace AGrynCo.Lib.StrUtils.FromStringConverters
{
    public interface IFromStringConverter
    {
        #region Abstract Methods
        object Convert(string value);
        #endregion
    }

    public interface IFromStringConverter<out TResult> : IFromStringConverter
    {
        #region Abstract Methods
        new TResult Convert(string value);
        #endregion
    }
}
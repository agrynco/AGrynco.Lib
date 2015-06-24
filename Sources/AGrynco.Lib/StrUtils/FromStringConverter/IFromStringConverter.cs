#region Usings
#endregion

namespace AGrynco.Lib.StrUtils.FromStringConverter
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
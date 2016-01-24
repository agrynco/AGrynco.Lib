#region Usings
#endregion

namespace AGrynCo.Lib.StrUtils.FromStringConverter
{
    [FromStringConverter]
    public class IdleFromStringConverter : BaseFromStringConverter<string>
    {
        #region Static Fields (public)
        public static readonly IdleFromStringConverter Instance = new IdleFromStringConverter();
        #endregion

        #region Methods (protected)
        protected override string DoConvert(string value)
        {
            return value;
        }
        #endregion
    }
}
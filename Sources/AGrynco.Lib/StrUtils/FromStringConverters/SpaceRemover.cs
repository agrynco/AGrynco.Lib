#region Usings
#endregion

namespace AGrynCo.Lib.StrUtils.FromStringConverters
{
    public class SpaceRemover : BaseFromStringConverter<string>
    {
        #region Methods (protected)
        protected override string DoConvert(string value)
        {
            return StrUtility.RemoveChars(value, ' ');
        }
        #endregion
    }
}
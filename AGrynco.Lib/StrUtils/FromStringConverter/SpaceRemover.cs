#region Usings
#endregion

namespace AGrynco.Lib.StrUtils.FromStringConverter
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
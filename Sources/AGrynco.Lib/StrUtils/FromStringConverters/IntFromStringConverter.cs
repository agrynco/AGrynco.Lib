namespace AGrynCo.Lib.StrUtils.FromStringConverter
{
    [FromStringConverter]
    public class IntFromStringConverter : BaseFromStringConverter<int>
    {
        #region Static Fields (public)
        public static readonly IntFromStringConverter Instance = new IntFromStringConverter();
        #endregion

        #region Methods (protected)
        protected override int DoConvert(string value)
        {
            return int.Parse(value);
        }
        #endregion
    }
}
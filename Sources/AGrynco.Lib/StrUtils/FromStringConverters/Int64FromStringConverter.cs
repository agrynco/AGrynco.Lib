#region Usings
using System;
#endregion

namespace AGrynCo.Lib.StrUtils.FromStringConverter
{
    [FromStringConverter]
    public class Int64FromStringConverter : BaseFromStringConverter<Int64>
    {
        #region Static Fields (public)
        public static readonly Int64FromStringConverter Instance = new Int64FromStringConverter();
        #endregion

        #region Methods (protected)
        protected override long DoConvert(string value)
        {
            return Int64.Parse(value);
        }
        #endregion
    }
}
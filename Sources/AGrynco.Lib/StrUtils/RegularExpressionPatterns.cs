#region Usings
#endregion

namespace AGrynCo.Lib.StrUtils
{
    public class RegularExpressionPatterns
    {
        #region Static Fields (public)
        /// <summary>
        /// dd/mm/aaaa
        /// </summary>
        public static readonly string Date = @"^([123]0|[012][1-9]|31)/(0[1-9]|1[012])/(19[0-9]{2}|2[0-9]{3})$";

        /// <summary>
        /// Formatted or not formatted number,having ,. as separators
        /// </summary>
        public static readonly string IntegerAndDecimal = @"^(-)?([1-9]\d*(\.|\,)\d*|0?(\.|\,)\d*[1-9]\d*|[1-9]\d*)$";

        /// <summary>
        /// Non empty single row string
        /// </summary>
        public static readonly string NonEmptyString = "^((.)+)$";

        /// <summary>
        /// Any non empty text
        /// </summary>
        public static readonly string NonEmptyText = "((.)+)";

        public static readonly string Email = @"^([0-9a-zA-Z].*?@([0-9a-zA-Z].*\.\w{2,4}))$";
        #endregion
    }
}
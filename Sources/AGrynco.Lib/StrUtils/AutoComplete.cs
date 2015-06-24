#region Usings
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
#endregion

namespace AGrynco.Lib.StrUtils
{
    public static class AutoComplete
    {
        #region Static Methods (public)
        public static string[] Prepare(string[] source, string searchQuery)
        {
            List<string> startsWith = source.Where(x => x.ToUpper().StartsWith(searchQuery, true, CultureInfo.InvariantCulture)).OrderBy(x => x).ToList();
            IEnumerable<string> rest = source.Where(x => !x.ToUpper().StartsWith(searchQuery, true, CultureInfo.InvariantCulture)).OrderBy(x => x);

            startsWith.AddRange(rest);
            return startsWith.ToArray();
        }
        #endregion
    }
}
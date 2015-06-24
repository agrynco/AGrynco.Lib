#region Usings
using System;
using System.Collections.Generic;
#endregion

namespace AGrynco.Lib
{
    public static class LinqHelpers
    {
        #region Static Methods (public)
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
        #endregion
    }
}
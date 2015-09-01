#region Usings
using System.Collections;
using System.Collections.Generic;
using AGrynCo.Lib.Exceptions;
#endregion

namespace AGrynCo.Lib.Collections
{
    public static class CollectionUtils
    {
        #region Static Methods (public)
        public static T GetFirst<T>(IEnumerable list)
        {
            IEnumerator enumerator = list.GetEnumerator();

            if (!enumerator.MoveNext())
            {
                return default(T);
            }

            return (T) enumerator.Current;
        }

        public static T GetSingle<T>(IEnumerable<T> list) where T : class
        {
            T result = GetSingleIfExists(list);

            if (result == null)
            {
                throw new ThereIsNoItemException();
            }

            return result;
        }

        public static T GetSingleIfExists<T>(IEnumerable<T> list) where T : class
        {
            IEnumerator<T> enumerator = list.GetEnumerator();

            if (!enumerator.MoveNext())
            {
                return default(T);
            }

            T result = enumerator.Current;

            if (enumerator.MoveNext())
            {
                throw new ToMuchItemsException();
            }

            return result;
        }
        #endregion

        #region Static Methods (private)
        public static T EnsureSingleObject<T>(IList<T> entities)
        {
            switch (entities.Count)
            {
                case 0:
                    throw new ThereIsNoItemException();
                case 1:
                    return entities[0];
                default:
                    throw new ToMuchItemsException(string.Format("Count = {0}", entities.Count));
            }
        }
        #endregion
    }
}
#region Usings
#endregion

namespace AGrynCo.Lib.Collections
{
    public class ReadOnlyCollection<TKey, TValue> : CustomCollection<TKey, TValue>
    {
        #region Methods (public)
        public bool ContainsKey(TKey key)
        {
            return ((ICustomCollection) this).ContainsKey(key);
        }
        #endregion

        #region Properties (public)
        public int Count
        {
            get { return ((ICustomCollection) this).Count; }
        }

        public TValue this[TKey key]
        {
            get { return (TValue) ((ICustomCollection) this)[key]; }
        }
        #endregion
    }
}
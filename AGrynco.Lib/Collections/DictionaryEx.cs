#region Usings
using System.Collections.Generic;
#endregion

namespace AGrynco.Lib.Collections
{
    public class DictionaryEx<TKey, TValue> : Dictionary<TKey, TValue>
    {
        #region Properties (public)
        public new TValue this[TKey key]
        {
            get
            {
                CheckForExisting(key);
                return base[key];
            }
            set
            {
                CheckForExisting(key);
                base[key] = value;
            }
        }
        #endregion

        #region Methods (private)
        private void CheckForExisting(TKey key)
        {
            if (ContainsKey(key))
            {
                return;
            }

            string message = string.Format("The given key ('{0}') was not present in the dictionary", key);
            throw new KeyNotFoundException(message);
        }
        #endregion
    }
}
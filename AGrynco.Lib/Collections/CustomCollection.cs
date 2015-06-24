#region Usings
using System.Collections;
using System.Collections.Generic;
#endregion

namespace AGrynco.Lib.Collections
{
    public class CustomCollection<TKey, TValue> : ICustomCollection
    {
        #region Fields (private)
        private readonly Dictionary<TKey, TValue> _items;
        #endregion

        #region Constructors
        public CustomCollection()
        {
            _items = new Dictionary<TKey, TValue>();
        }
        #endregion

        #region ICustomCollection Properties
        int ICustomCollection.Count
        {
            get { return _items.Count; }
        }

        object ICustomCollection.this[object key]
        {
            get { return _items[(TKey) key]; }
            set { _items[(TKey) key] = (TValue) value; }
        }
        #endregion

        #region ICustomCollection Methods
        public IEnumerator GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        void ICustomCollection.Add(object key, object value)
        {
            _items.Add((TKey) key, (TValue) value);
        }

        void ICustomCollection.Clear()
        {
            _items.Clear();
        }

        bool ICustomCollection.ContainsKey(object key)
        {
            return _items.ContainsKey((TKey) key);
        }

        void ICustomCollection.Remove(object key)
        {
            _items.Remove((TKey) key);
        }
        #endregion
    }
}
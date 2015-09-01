#region Usings
using System.Collections;
using System.Collections.Generic;
using AGrynCo.Lib.StrUtils;
#endregion

namespace AGrynCo.Lib.Collections
{
    public class CustomList<TItem> : ICustomList<TItem>
    {
        #region Fields (private)
        private readonly List<TItem> _items;
        #endregion

        #region Constructors
        public CustomList()
        {
            _items = new List<TItem>();
        }

        public CustomList(IEnumerable<TItem> items) : this()
        {
            _items.AddRange(items);
        }
        #endregion

        #region ICustomList<TItem> Properties
        public int Count
        {
            get { return _items.Count; }
        }

        public bool IsReadOnly
        {
            get { return ((IList<TItem>) _items).IsReadOnly; }
        }

        public TItem this[int index]
        {
            get { return _items[index]; }
            set { _items[index] = value; }
        }
        #endregion

        #region ICustomList<TItem> Methods
        public IEnumerator<TItem> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        void ICollection<TItem>.Add(TItem item)
        {
            _items.Add(item);
        }

        void ICollection<TItem>.Clear()
        {
            _items.Clear();
        }

        bool ICollection<TItem>.Contains(TItem item)
        {
            return _items.Contains(item);
        }

        void ICollection<TItem>.CopyTo(TItem[] array, int arrayIndex)
        {
            _items.CopyTo(array, arrayIndex);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        int IList<TItem>.IndexOf(TItem item)
        {
            return _items.IndexOf(item);
        }

        void IList<TItem>.Insert(int index, TItem item)
        {
            _items.Insert(index, item);
        }

        bool ICollection<TItem>.Remove(TItem item)
        {
            return _items.Remove(item);
        }

        void IList<TItem>.RemoveAt(int index)
        {
            _items.RemoveAt(index);
        }

        void ICustomList<TItem>.Sort(IComparer<TItem> comparer)
        {
            _items.Sort(comparer);
        }
        #endregion

        #region Methods (public)
        public string ItemsToString(string separator)
        {
            string[] strItems = new string[Count];
            for (int i = 0; i < Count; i++)
            {
                strItems[i] = this[i].ToString();
            }

            return StrUtility.Concat(strItems, separator);
        }
        #endregion
    }
}
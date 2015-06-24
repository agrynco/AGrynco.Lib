#region Usings
#endregion

namespace AGrynco.Lib.Collections
{
    public class TrackedCollection<TKey, TValue> : ReadOnlyCollection<TKey, TValue>
    {
        #region Fields (private)
        private readonly ReadOnlyCollection<TKey, TValue> _added;
        private readonly ReadOnlyCollection<TKey, TValue> _modified;
        private readonly ReadOnlyCollection<TKey, TValue> _removed;

        private bool _isTracked;
        #endregion

        #region Constructors
        public TrackedCollection()
        {
            _added = new ReadOnlyCollection<TKey, TValue>();
            _modified = new ReadOnlyCollection<TKey, TValue>();
            _removed = new ReadOnlyCollection<TKey, TValue>();

            _isTracked = true;
        }
        #endregion

        #region Methods (public)
        public void Add(TKey key, TValue value)
        {
            ((ICustomCollection) this).Add(key, value);
            if (_isTracked)
            {
                ((ICustomCollection) _added).Add(key, value);
            }
        }

        public void Clear()
        {
            bool isTracked = _isTracked;

            if (isTracked)
            {
                StopTrack();
            }

            ((ICustomCollection) this).Clear();

            if (isTracked)
            {
                StartTrack();
            }
        }

        public void Remove(TKey key)
        {
            if (_isTracked)
            {
                if (_added.ContainsKey(key))
                {
                    ((ICustomCollection) _added).Remove(key);
                }
                else
                {
                    if (_modified.ContainsKey(key))
                    {
                        ((ICustomCollection) _modified).Remove(key);
                    }

                    ((ICustomCollection) _removed).Add(key, this[key]);
                }
            }

            ((ICustomCollection) this).Remove(key);
        }

        public void StartTrack()
        {
            _isTracked = true;
        }

        public void StopTrack()
        {
            _isTracked = false;
            Commit();
        }
        #endregion

        #region Methods (private)
        private void Commit()
        {
            ((ICustomCollection) _removed).Clear();
            ((ICustomCollection) _modified).Clear();
            ((ICustomCollection) _added).Clear();
        }
        #endregion

        #region Properties (public)
        public ReadOnlyCollection<TKey, TValue> Added
        {
            get { return _added; }
        }

        public bool IsTracked
        {
            get { return _isTracked; }
        }

        public new TValue this[TKey key]
        {
            get { return base[key]; }
            set
            {
                if (!this[key].Equals(value))
                {
                    if (_isTracked)
                    {
                        if (!(_modified.ContainsKey(key)))
                        {
                            ((ICustomCollection) _modified).Add(key, base[key]);
                        }
                    }
                    ((ICustomCollection) this)[key] = value;
                }
            }
        }

        public ReadOnlyCollection<TKey, TValue> Modified
        {
            get { return _modified; }
        }

        public ReadOnlyCollection<TKey, TValue> Removed
        {
            get { return _removed; }
        }
        #endregion
    }
}
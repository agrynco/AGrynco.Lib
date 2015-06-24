#region Usings
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using AGrynco.Lib.Data.Repository.Exceptions;
#endregion

namespace AGrynco.Lib.Data.Repository
{
    public abstract class BaseMultiKey : IMultiKey, IEnumerable<IKey>
    {
        #region Constants
        private const string _KEY_VALUE_SEPARATOR = "; ";
        #endregion

        #region Fields (private)
        /// <summary>
        /// Dictionary used insteed array for quick access by key.
        /// </summary>
        private readonly Dictionary<string, IKey> _keyList;
        #endregion

        #region Constructors
        public BaseMultiKey()
        {
            _keyList = new Dictionary<string, IKey>();
            IKey[] keys = BuildPrimaryKeys();
            if (keys == null)
            {
                throw new NullReferenceException("Property 'PrimaryKeys' should not be equall null.");
            }
            foreach (IKey primaryKey in keys)
            {
                if (!_keyList.ContainsKey(primaryKey.Name))
                {
                    _keyList.Add(primaryKey.Name, primaryKey);
                }
                else
                {
                    throw new AreDublicateKeysException(
                        string.Format("Check PrimaryKeys for key '{0}'",
                            primaryKey.Name));
                }
            }
        }

        protected BaseMultiKey(string value) : this()
        {
            Assign(value);
        }
        #endregion

        #region IMultiKey Properties
        public bool AllKeysHasValue
        {
            get
            {
                foreach (KeyValuePair<string, IKey> keyValuePair in _keyList)
                {
                    if (keyValuePair.Value.Value == null)
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        public IKey this[string keyName]
        {
            get { return _keyList[keyName]; }
        }
        #endregion

        #region IEnumerable<IKey> Methods
        public IEnumerator<IKey> GetEnumerator()
        {
            return _keyList.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion

        #region IMultiKey Methods
        public void Assign(IMultiKey multyKey)
        {
            if (GetType() != multyKey.GetType())
            {
                throw new IdentifiersAreNotCompatibleException(
                    string.Format("Id '{0}' is not compatible with '{1}' but they must",
                        GetType(), multyKey.GetType()));
            }

            foreach (IKey primaryKey in this)
            {
                primaryKey.Value = multyKey[primaryKey.Name].Value;
            }
        }

        public abstract object Clone();
        #endregion

        #region Abstract Methods
        public abstract bool IsEquals(BaseMultiKey multiKey);

        /// <summary>
        /// Return list of primary keys
        /// </summary>
        protected abstract IKey[] BuildPrimaryKeys();
        #endregion

        #region Methods (public)
        public void Assign(string value)
        {
            string[] parts = value.Split(new[] {_KEY_VALUE_SEPARATOR}, StringSplitOptions.None);
            foreach (string part in parts)
            {
                string[] keyValue = part.Split(new[] {" = "}, StringSplitOptions.None);
                this[keyValue[0]].Assign(keyValue[1]);
            }
        }

        public override bool Equals(object obj)
        {
            return IsEquals((BaseMultiKey) obj);
        }

        public override int GetHashCode()
        {
            return (_keyList != null ? _keyList.GetHashCode() : 0);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            foreach (KeyValuePair<string, IKey> keyValuePair in _keyList)
            {
                if (result.Length > 0)
                {
                    result.Append(_KEY_VALUE_SEPARATOR);
                }
                result.Append(string.Format("{0} = {1}",
                    keyValuePair.Value.Name,
                    keyValuePair.Value.Value));
            }
            return result.ToString();
        }
        #endregion
    }
}
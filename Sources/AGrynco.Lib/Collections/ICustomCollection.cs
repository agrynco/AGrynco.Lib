#region Usings
using System.Collections;
#endregion

namespace AGrynCo.Lib.Collections
{
    public interface ICustomCollection : IEnumerable
    {
        #region Abstract Methods
        void Add(object key, object value);
        void Clear();
        bool ContainsKey(object key);
        void Remove(object key);
        #endregion

        #region Properties (public)
        int Count { get; }
        object this[object key] { get; set; }
        #endregion
    }
}
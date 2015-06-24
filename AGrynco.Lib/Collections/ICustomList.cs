#region Usings
using System.Collections.Generic;
#endregion

namespace AGrynco.Lib.Collections
{
    public interface ICustomList<TItem> : IList<TItem>
    {
        #region Abstract Methods
        void Sort(IComparer<TItem> comparer);
        #endregion
    }
}
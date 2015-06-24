#region Usings
using System;

using AGrynco.Lib.Data.DataProviders;
#endregion

namespace AGrynco.Lib.Data.Repository
{
    public interface IRepository : IDisposable
    {
        #region Properties (public)
        IDataProvider DataProvider { get; }
        #endregion
    }
}
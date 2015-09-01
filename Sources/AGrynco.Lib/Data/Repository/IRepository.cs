#region Usings
using System;
using AGrynCo.Lib.Data.DataProviders;
#endregion

namespace AGrynCo.Lib.Data.Repository
{
    public interface IRepository : IDisposable
    {
        #region Properties (public)
        IDataProvider DataProvider { get; }
        #endregion
    }
}
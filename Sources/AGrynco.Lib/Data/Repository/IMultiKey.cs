using System;

namespace AGrynCo.Lib.Data.Repository
{
    #region Usings
    
    #endregion

    public interface IMultiKey : ICloneable
    {
        #region Abstract Methods
        void Assign(IMultiKey multyKey);
        #endregion

        #region Properties (public)
        bool AllKeysHasValue { get; }

        IKey this[string keyName] { get; }
        #endregion
    }
}
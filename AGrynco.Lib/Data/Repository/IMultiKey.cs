using System;

namespace AGrynco.Lib.Data.Repository
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
#region Usings
using System;
using System.Collections.Generic;
#endregion

namespace AGrynco.Lib.Containers
{
    public interface IContainer : IEnumerable<Type>
    {
        #region Abstract Methods
        void RegisterType(Type key);
        void RegisterType(Type key, Type value);
        #endregion

        #region Properties (public)
        int Count { get; }
        object this[Type index] { get; }
        #endregion
    }
}
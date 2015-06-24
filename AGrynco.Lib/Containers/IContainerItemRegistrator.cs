#region Usings
using System;
using System.Reflection;
#endregion

namespace AGrynco.Lib.Containers
{
    public interface IContainerItemRegistrator
    {
        #region Abstract Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="container"></param>
        /// <param name="assemblies"></param>
        /// <param name="attributeTypes"></param>
        /// <returns>Number of registered items</returns>
        int RegisterItems(IContainer container, Assembly[] assemblies, Type[] attributeTypes);
        #endregion
    }
}
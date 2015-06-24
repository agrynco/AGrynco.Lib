#region Usings
using System;
using System.Reflection;
#endregion

namespace AGrynco.Lib.Containers
{
    public class ContainerItemRegistrator : IContainerItemRegistrator
    {
        #region IContainerItemRegistrator Methods
        public int RegisterItems(IContainer container, Assembly[] assemblies, Type[] attributeTypes)
        {
            Type[] itemsToRegister = AssemblyScanner.Search(assemblies, attributeTypes);
            foreach (Type typeItem in itemsToRegister)
            {
                DoRegisterType(container, typeItem);
            }
            return itemsToRegister.Length;
        }
        #endregion

        #region Methods (protected)
        protected virtual void DoRegisterType(IContainer container, Type type)
        {
            container.RegisterType(type);
        }
        #endregion
    }
}
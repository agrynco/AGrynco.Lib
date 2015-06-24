#region Usings
using System;

using AGrynco.Lib.Containers;
#endregion

namespace AGrynco.Lib.StrUtils.FromStringConverter
{
    public class FromStringConverterRegistrator : ContainerItemRegistrator
    {
        #region Methods (protected)
        protected override void DoRegisterType(IContainer container, Type type)
        {
            Type[] genericArguments = type.BaseType.GetGenericArguments();
            container.RegisterType(genericArguments[0], type);
        }
        #endregion
    }
}
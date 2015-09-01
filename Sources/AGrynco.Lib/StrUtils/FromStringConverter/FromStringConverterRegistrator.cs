#region Usings
using System;
using AGrynCo.Lib.Containers;
#endregion

namespace AGrynCo.Lib.StrUtils.FromStringConverter
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
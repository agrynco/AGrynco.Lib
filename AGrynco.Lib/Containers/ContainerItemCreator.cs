#region Usings
using System;
#endregion

namespace AGrynco.Lib.Containers
{
    public class ContainerItemCreator : IContainerItemCreator<ItemCreatorParamsEmpty>
    {
        #region IContainerItemCreator<ItemCreatorParamsEmpty> Methods
        public object Create(Type typeOfItem, ItemCreatorParamsEmpty parameters)
        {
            try
            {
                return Activator.CreateInstance(typeOfItem);
            }
            catch (Exception)
            {
                throw new MissingMethodException(string.Format("No parameterless constructor defined for type '{0}'",
                                                               typeOfItem));
            }
        }
        #endregion
    }
}
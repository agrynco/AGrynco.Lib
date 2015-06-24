#region Usings
using AGrynco.Lib.Containers;
#endregion

namespace AGrynco.Lib.StrUtils.FromStringConverter
{
    public class FromStringConvertersContainer :
        ContainerBase<ContainerItemCreator, ItemCreatorParamsEmpty, FromStringConverterRegistrator>
    {
        #region Constructors
        public FromStringConvertersContainer(TypeCriteria typeSearchCriteria)
            : base(typeSearchCriteria, new ItemCreatorParamsEmpty())
        {
        }
        #endregion
    }
}
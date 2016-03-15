#region Usings
using AGrynCo.Lib.Containers;
#endregion

namespace AGrynCo.Lib.StrUtils.FromStringConverters
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
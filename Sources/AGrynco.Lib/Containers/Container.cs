namespace AGrynCo.Lib.Containers
{
    public class Container : ContainerBase<ContainerItemCreator, ItemCreatorParamsEmpty, ContainerItemRegistrator>
    {
        #region Constructors
        public Container(TypeCriteria typeSearchCriteria) : base(typeSearchCriteria, new ItemCreatorParamsEmpty())
        {
        }
        #endregion
    }
}
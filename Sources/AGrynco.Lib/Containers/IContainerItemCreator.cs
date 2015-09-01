#region Usings
using System;
#endregion

namespace AGrynCo.Lib.Containers
{
    public interface IContainerItemCreator<TParams>
        where TParams : IContainerItemCreatorParameters
    {
        #region Abstract Methods
        object Create(Type typeOfItem, TParams parameters);
        #endregion
    }
}
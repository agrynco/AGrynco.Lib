#region Usings
#endregion

namespace AGrynCo.Lib.RandomGenerators
{
    public abstract class BaseRandomGenerator<T> : IRandomGenerator
    {
        #region IRandomGenerator Methods
        object IRandomGenerator.Generate()
        {
            return Generate();
        }
        #endregion

        #region Abstract Methods
        public abstract T Generate();
        #endregion
    }
}
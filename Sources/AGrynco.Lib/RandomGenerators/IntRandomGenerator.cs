using System;

namespace AGrynco.Lib.RandomGenerators
{
    #region Usings
    
    #endregion

    [RandomGenerator]
    public class IntRandomGenerator : BaseRandomGenerator<int>
    {
        #region Static Fields (private)
        private static readonly Random _random = new Random();
        #endregion

        #region Methods (public)
        public override int Generate()
        {
            return _random.Next(Int32.MinValue, Int32.MaxValue);
        }
        #endregion
    }
}
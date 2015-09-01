using System;

namespace AGrynCo.Lib.RandomGenerators
{
    #region Usings
    
    #endregion

    [RandomGenerator]
    public class DecimalRandomGenerator : BaseRandomGenerator<decimal>
    {
        #region Static Fields (private)
        private static readonly Random _random = new Random();
        #endregion

        #region Methods (public)
        public override decimal Generate()
        {
            return new decimal(_random.Next(1, 10));
        }
        #endregion
    }
}
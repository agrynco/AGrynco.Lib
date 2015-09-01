#region Usings
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
#endregion

namespace AGrynCo.Lib.RandomGenerators
{

    #region Usings
    #endregion

    public class RandomGenerator : BaseSingletone<RandomGenerator>
    {
        #region Fields (private)
        private readonly Dictionary<Type, IRandomGenerator> _randomGenerators = new Dictionary<Type, IRandomGenerator>();
        #endregion

        #region Constructors
        public RandomGenerator()
        {
            Type[] typesOfRandomGenerator = AssemblyScanner.Search(Assembly.GetAssembly(this.GetType()), new[] { typeof(RandomGeneratorAttribute) });
            foreach (Type typeOfRandomGenerator in typesOfRandomGenerator)
            {
                Debug.Assert(typeOfRandomGenerator.BaseType != null, "typeOfRandomGenerator.BaseType != null");
                this._randomGenerators.Add(typeOfRandomGenerator.BaseType.GenericTypeArguments[0], (IRandomGenerator)Activator.CreateInstance(typeOfRandomGenerator));
            }
        }
        #endregion

        #region Methods (public)
        public object Generate(Type targetType)
        {
            if (this._randomGenerators.ContainsKey(targetType))
            {
                return this._randomGenerators[targetType].Generate();
            }

            throw new KeyNotFoundException(string.Format("There is no RandomGenerator for type = {0}", targetType));
        }

        public T Generate<T>()
        {
            return (T)this.Generate(typeof(T));
        }
        #endregion
    }
}
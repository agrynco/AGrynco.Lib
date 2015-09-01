#region Usings
using System;
using System.Collections.Generic;
using System.Reflection;
#endregion

namespace AGrynCo.Lib
{
    public static class ConverterFactory
    {
        #region Static Fields (private)
        private static readonly Dictionary<Type, IValueConverter> _VALUE_CONVERTERS;
        #endregion

        #region Constructors
        static ConverterFactory()
        {
            _VALUE_CONVERTERS = MakeSetOfConverters();
        }
        #endregion

        #region Static Methods (public)
        public static IValueConverter<T> GetConvrter<T>()
        {
            try
            {
                return (IValueConverter<T>)_VALUE_CONVERTERS[typeof(T)];
            }
            catch (KeyNotFoundException)
            {
                throw new ConverterNotFoundException(typeof(T));
            }
        }
        #endregion

        #region Static Methods (private)
        private static Dictionary<Type, IValueConverter> MakeSetOfConverters()
        {
            Assembly assembly = Assembly.GetAssembly(typeof(IValueConverter));
            Type[] converterTypes = AssemblyScanner.Search(assembly, new[] { typeof(ConverterAttribute) });

            Dictionary<Type, IValueConverter> list = new Dictionary<Type, IValueConverter>();

            foreach (Type converterType in converterTypes)
            {
                var instance = (IValueConverter)Activator.CreateInstance(converterType);
                list.Add(instance.ConversionResultType, instance);
            }

            return list;
        }
        #endregion
    }
}
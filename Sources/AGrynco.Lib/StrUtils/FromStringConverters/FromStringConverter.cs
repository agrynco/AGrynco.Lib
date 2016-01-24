#region Usings
using System;
using AGrynCo.Lib.Containers;
using AGrynCo.Lib.StrUtils.FromStringConverter;
#endregion

namespace AGrynCo.Lib.StrUtils.FromStringConverters
{
    public static class FromStringConverter
    {
        #region Static Fields (private)
        private static readonly FromStringConvertersContainer _CONVERTERS_CONTAINER;
        #endregion

        #region Constructors
        static FromStringConverter()
        {
            _CONVERTERS_CONTAINER = new FromStringConvertersContainer(new TypeCriteria(new[] { typeof(FromStringConverter) }, new[] { typeof(FromStringConverterAttribute) }));
        }
        #endregion

        #region Static Methods (public)
        public static object Convert(Type type, string value)
        {
            object result = ((IFromStringConverter)_CONVERTERS_CONTAINER[type]).Convert(value);

            return result;
        }

        public static T Convert<T>(string value)
        {
            if (typeof(T).IsEnum)
            {
                return (T)Enum.Parse(typeof(T), value);
            }

            return ((IFromStringConverter<T>)_CONVERTERS_CONTAINER[typeof(T)]).Convert(value);
        }
        #endregion
    }
}
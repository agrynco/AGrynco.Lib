#region Usings
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
#endregion

namespace AGrynCo.Lib
{
    public static class TypeUtil
    {
        #region Static Methods (public)
        public static T Cast<T>(object o)
        {
            try
            {
                var converter = new Converter();

                return converter.Convert<T>(o);
            }
            catch (ConverterNotFoundException ex)
            {
                //Logger.Exception(ex);

                throw new InvalidCastException(string.Format("Can not cast value '{0}' of type {1} to type {2}", o, o.GetType(), typeof(T)), ex);
            }
        }

        public static object GetDefault(Type type)
        {
            if (type.IsValueType)
            {
                return Activator.CreateInstance(type);
            }
            else
            {
                return null;
            }
        }

        public static PropertyInfo GetPropertyInfo<TSource, TProperty>(TSource source, Expression<Func<TSource, TProperty>> propertyLambda)
        {
            Type type = typeof(TSource);

            MemberExpression member = propertyLambda.Body as MemberExpression;
            if (member == null)
            {
                throw new ArgumentException(string.Format("Expression '{0}' refers to a method, not a property.", propertyLambda));
            }

            PropertyInfo propInfo = member.Member as PropertyInfo;
            if (propInfo == null)
            {
                throw new ArgumentException(string.Format("Expression '{0}' refers to a field, not a property.", propertyLambda));
            }

            if (type != propInfo.ReflectedType && !type.IsSubclassOf(propInfo.ReflectedType))
            {
                throw new ArgumentException(string.Format("Expresion '{0}' refers to a property that is not from type {1}.", propertyLambda, type));
            }

            return propInfo;
        }

        public static bool IsInheritFrom(Type type, Type baseType)
        {
            if (type != baseType)
            {
                if (type.BaseType != null)
                {
                    return IsInheritFrom(type.BaseType, baseType);
                }
            }
            else
            {
                return true;
            }
            return false;
        }

        public static bool IsNullableType(Type theType)
        {
            return (theType.IsGenericType && theType.GetGenericTypeDefinition() == typeof(Nullable<>));
        }

        public static bool IsOneOf(Type type, IEnumerable<Type> types)
        {
            foreach (Type excludedType in types)
            {
                if (excludedType.IsInterface)
                {
                    if (IsSupportInteface(type, excludedType))
                    {
                        return true;
                    }
                }
                else if ((type == excludedType))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsSupportInteface(Type type, Type interfaceType)
        {
            Type[] interfaces = type.GetInterfaces();
            return interfaces.Any(currentInterfaceType => currentInterfaceType == interfaceType);
        }
        #endregion
    }
}
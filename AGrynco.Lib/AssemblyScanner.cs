#region Usings
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
#endregion

namespace AGrynco.Lib
{
    public static class AssemblyScanner
    {
        #region Static Methods (public)
        /// <summary>
        /// Search specified types in assembly
        /// </summary>
        /// <param name="assembly">Assembly to be scanned</param>
        /// <param name="typeCriteria">Type to search</param>
        /// <returns>Array of types</returns>
        public static Type[] Search(Assembly assembly, Type typeCriteria)
        {
            return Search(assembly, typeCriteria, true, true);
        }

        public static Type[] Search(Assembly assembly, Type typeCriteria, bool excludeInterfaces, bool excludeAbstractClasses)
        {
            List<Type> result = new List<Type>();
            result.AddRange(assembly.GetTypes());
            for (int i = result.Count - 1; i > -1; i--)
            {
                if (!typeCriteria.IsAssignableFrom(result[i]))
                {
                    result.RemoveAt(i);
                }
                else
                {
                    bool alreadyRemoved = false;

                    if (excludeInterfaces)
                    {
                        if (result[i].IsInterface)
                        {
                            result.RemoveAt(i);
                            alreadyRemoved = true;
                        }
                    }

                    if (!alreadyRemoved)
                    {
                        if (excludeAbstractClasses)
                        {
                            if (result[i].IsAbstract)
                            {
                                result.RemoveAt(i);
                            }
                        }
                    }
                }
            }
            return result.ToArray();
        }

        public static Type[] Search(Assembly[] assemblies, Type[] attributeTypes)
        {
            List<Assembly> assembliesToScan = new List<Assembly>();

            if ((assemblies != null) && (assemblies.Length != 0))
            {
                assembliesToScan.AddRange(assemblies);
            }
            else
            {
                assembliesToScan.AddRange(AppDomain.CurrentDomain.GetAssemblies());
            }

            List<Type> result = new List<Type>();
            foreach (Assembly assembly in assembliesToScan)
            {
                result.AddRange(Search(assembly, attributeTypes));
            }
            return result.ToArray();
        }

        public static Type[] Search(Assembly assembly, Type[] attributeTypes)
        {
            List<Type> result = new List<Type>(assembly.GetTypes());
            for (int i = result.Count - 1; i > -1; i--)
            {
                List<object> customAttributes = new List<object>();
                foreach (Type attributeType in attributeTypes)
                {
                    object[] attributes = result[i].GetCustomAttributes(false);
                    Type type = attributeType;
                    customAttributes.AddRange(attributes.Where(ca => ca.GetType().FullName == type.FullName));
                }
                if (customAttributes.Count == 0)
                {
                    result.RemoveAt(i);
                }
            }
            return result.ToArray();
        }

        public static Type[] Search(Type desiredType)
        {
            return AppDomain.CurrentDomain.GetAssemblies().SelectMany(assembly => assembly.GetTypes()).Where(type => desiredType.IsAssignableFrom(type) && !desiredType.IsEquivalentTo(type)).ToArray();
        }

        public static Type Search(string fullTypeName)
        {
            Type result = AppDomain.CurrentDomain.GetAssemblies().SelectMany(assembly => assembly.GetTypes()).FirstOrDefault(type => type.FullName == fullTypeName);

            if (result == null)
            {
                throw new AssemblyScannerException(string.Format("Can not find assembly which contains implementation of {0}", fullTypeName));
            }

            return result;
        }
        #endregion
    }
}
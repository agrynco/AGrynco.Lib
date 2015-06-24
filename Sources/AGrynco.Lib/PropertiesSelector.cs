#region Usings
using System;
using System.Collections.Generic;
using System.Reflection;
#endregion

namespace AGrynco.Lib
{
    public class PropertiesSelector
    {
        #region Static Methods (public)
        public static PropertyInfo[] GetPropertyInfo(Type type, Type[] excludeTypes)
        {
            var result = new List<PropertyInfo>(type.GetProperties());
            for (int i = result.Count - 1; i > -1; i--)
            {
                if (TypeUtil.IsOneOf(result[i].PropertyType, excludeTypes))
                {
                    result.RemoveAt(i);
                }
            }
            return result.ToArray();
        }
        #endregion
    }
}
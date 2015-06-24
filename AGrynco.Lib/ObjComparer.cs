#region Usings
using System;
using System.Reflection;
#endregion

namespace AGrynco.Lib
{
    public class ObjComparer
    {
        #region Static Methods (public)
        public static bool AreEquals(object obj1, object obj2)
        {
            Type type1 = obj1.GetType();
            Type type2 = obj2.GetType();
            if (type1 != type2)
            {
                throw new ArgumentException(string.Format("Types of objects to compare must be equal. Actual types are: Type1 = '{0}'; Type2 = '{1}'", type1, type2));
            }
            PropertyInfo[] propertyInfos = type1.GetProperties();
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                Type propertyType = propertyInfo.PropertyType;
                object value1 = propertyInfo.GetValue(obj1, null);
                object value2 = propertyInfo.GetValue(obj2, null);
                if (!propertyType.IsClass || (propertyType == typeof(string)))
                {
                    if (!value1.Equals(value2))
                    {
                        return false;
                    }
                }
                else
                {
                    bool result = AreEquals(value1, value2);
                    if (!result)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        #endregion
    }
}
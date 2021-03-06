#region Usings
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AGrynCo.Lib.Exceptions;
using AGrynCo.Lib.ToStringConverters;
#endregion

namespace AGrynCo.Lib
{
    public class BaseClass
    {
        #region Methods (public)
        public virtual BaseClass Assign(object source)
        {
            PropertyInfo[] propertyInfos = GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public).Where(x => x.GetCustomAttribute(typeof(IgnoreAttribute)) == null).ToArray();
            List<string> absentProperties = new List<string>();
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                try
                {
                    propertyInfo.SetValue(this, PropertyValueManager.GetValue(propertyInfo.Name, source));
                }
                catch (ArgumentException ex)
                {
                    throw new CanNotAssignPropertyException(
                        string.Format("Can not assign property '{0}' from " + "instance of '{1}' to instance of '{2}'", propertyInfo.Name, source.GetType(), GetType()),
                        ex);
                }
                catch (ThereIsNoPropertyException)
                {
                    absentProperties.Add(propertyInfo.Name);
                }
            }
            if (absentProperties.Count > 0)
            {
                throw new ThereIsNoPropertyException(absentProperties, source);
            }

            return this;
        }

        public override string ToString()
        {
            return ToStringConverter.ConvertClass(this);
        }
        #endregion
    }

    public class BaseClass<T> : BaseClass
        where T : BaseClass<T>
    {
        #region Static Methods (public)
        public static PropertyInfo GetPropertyInfo(string propertyName)
        {
            return typeof(T).GetProperty(propertyName);
        }
        #endregion
    }
}
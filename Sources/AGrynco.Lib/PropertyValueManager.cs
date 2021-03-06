﻿#region Usings
using System;
using System.Reflection;
using AGrynCo.Lib.Exceptions;
#endregion

namespace AGrynCo.Lib
{
    public class PropertyValueManager
    {
        #region Static Fields (public)
        public static readonly char PROPERTY_SEPARATOR = '.';
        #endregion

        #region Nested type: PropertyInfoAndObj
        internal class PropertyInfoAndObj
        {
            #region Constructors
            public PropertyInfoAndObj(PropertyInfo propertyInfo, object ownerOfProperty)
            {
                _propertyInfo = propertyInfo;
                _ownerOfProperty = ownerOfProperty;
            }
            #endregion

            #region Fields (private)
            private readonly object _ownerOfProperty;

            private readonly PropertyInfo _propertyInfo;
            #endregion

            #region Properties (public)
            public object OwnerOfProperty
            {
                get
                {
                    return _ownerOfProperty;
                }
            }

            public PropertyInfo PropertyInfo
            {
                get
                {
                    return _propertyInfo;
                }
            }
            #endregion
        }
        #endregion

        #region Static Methods (public)
        public static object GetValue(string fullPropertyName, object source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source", "Parameter 'source' must be different from null");
            }
            PropertyInfoAndObj propertyInfoAndObj = GetPropertyPropertyInfoAndObjForFinalProperty(source, fullPropertyName);
            return propertyInfoAndObj.PropertyInfo.GetValue(propertyInfoAndObj.OwnerOfProperty, null);
        }

        /// <summary>
        /// Sets the <see cref="value"/> to the <see cref="fullPropertyName"/>
        /// </summary>
        /// <param name="destination">Object which contains the property with <see cref="fullPropertyName"/></param>
        /// <param name="fullPropertyName"> name of the property to be changed</param>
        /// <param name="value">Value of the property to be setted</param>
        public static void SetValue(object destination, string fullPropertyName, object value)
        {
            object valueToSet = value == DBNull.Value ? null : value;

            PropertyInfoAndObj propertyInfoAndObj = GetPropertyPropertyInfoAndObjForFinalProperty(destination, fullPropertyName);

            propertyInfoAndObj.PropertyInfo.SetValue(propertyInfoAndObj.OwnerOfProperty, valueToSet, null);
        }
        #endregion

        #region Static Methods (private)
        private static PropertyInfoAndObj GetPropertyPropertyInfoAndObjForFinalProperty(object obj, string fullPropertyName)
        {
            object referenceToOwnerOfProperty = GetReferenceToPropertyOwner(fullPropertyName, obj);
            string[] pathToPropertyParts = fullPropertyName.Split(PROPERTY_SEPARATOR);

            string newPropertyName = pathToPropertyParts.Length > 1 ? pathToPropertyParts[pathToPropertyParts.Length - 1] : fullPropertyName;

            PropertyInfo propertyInfo = referenceToOwnerOfProperty.GetType().GetProperty(newPropertyName);

            if (propertyInfo == null)
            {
                throw new ThereIsNoPropertyException(fullPropertyName, obj);
            }

            return new PropertyInfoAndObj(propertyInfo, referenceToOwnerOfProperty);
        }

        private static object GetReferenceToPropertyOwner(string pathToProperty, object source)
        {
            string[] pathToPropertyParts = pathToProperty.Split(PROPERTY_SEPARATOR);
            if (pathToPropertyParts.Length > 1)
            {
                string ownerOfProperty = string.Join(PROPERTY_SEPARATOR.ToString(), pathToPropertyParts, 0, pathToPropertyParts.Length - 1);

                return GetValue(ownerOfProperty, source);
            }

            return source;
        }
        #endregion
    }
}
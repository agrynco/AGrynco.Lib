#region Usings
using System;
using System.Diagnostics;
using System.Reflection;

using AGrynco.Lib.ToStringConverters;
#endregion

namespace AGrynco.Lib.Data.Repository
{
    public abstract class BaseEntity<TIdentifier> : BaseClass, IEntity
        where TIdentifier : IMultiKey, new()
    {
        #region Fields (private)
        private readonly TIdentifier _id;
        #endregion

        #region Constructors
        protected BaseEntity()
        {
            this._id = new TIdentifier();
        }
        #endregion

        #region Properties (public)
        public virtual TIdentifier Id
        {
            [DebuggerStepThrough]
            get
            {
                return this._id;
            }
        }
        #endregion

        #region IEntity Properties
        IMultiKey IEntity.MultiKey
        {
            [DebuggerStepThrough]
            get
            {
                return this.Id;
            }
        }
        #endregion

        #region Methods (public)
        public override bool Equals(object obj)
        {
            Type type = this.GetType();
            Type objType = obj.GetType();
            Debug.Assert(type == objType, String.Format("Types of objects to compare must be equal. Actual types are: Type1 = '{0}'; Type2 = '{1}'", type, objType));
            PropertyInfo[] propertyInfos = type.GetProperties();
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                if (propertyInfo.GetType().IsValueType)
                {
                    if (!propertyInfo.GetValue(this, null).Equals(propertyInfo.GetValue(obj, null)))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool Equals(BaseEntity<TIdentifier> obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            return Equals(obj._id, this._id);
        }

        public override int GetHashCode()
        {
            return this._id.GetHashCode();
        }

        public override string ToString()
        {
            return ToStringConverter.ConvertClass(this);
        }
        #endregion
    }
}
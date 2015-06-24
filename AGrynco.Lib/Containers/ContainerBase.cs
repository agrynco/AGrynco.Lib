#region Usings
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

using AGrynco.Lib.Exceptions;
#endregion

namespace AGrynco.Lib.Containers
{
    public class ContainerBase<TContainerItemCreator, TContainerItemCreatorParameters, TContainerItemRegistrator> : IContainer
        where TContainerItemCreator : IContainerItemCreator<TContainerItemCreatorParameters>, new()
        where TContainerItemCreatorParameters : IContainerItemCreatorParameters
        where TContainerItemRegistrator : IContainerItemRegistrator, new()
    {
        #region Constructors
        public ContainerBase(TypeCriteria typeSearchCriteria, TContainerItemCreatorParameters containerItemCreatorParameters)
        {
            _typeSearchCriteria = typeSearchCriteria;
            _containerItemCreatorParameters = containerItemCreatorParameters;
            _containerItemCreator = new TContainerItemCreator();
            _items = new Dictionary<Type, object>();
            new TContainerItemRegistrator().RegisterItems(this, TypeSearchCriteria.Assemblies, TypeSearchCriteria.AttributeTypes);
        }
        #endregion

        #region Methods (public)
        public bool Contains(Type type)
        {
            return _items.ContainsKey(type);
        }
        #endregion

        #region Methods (protected)
        protected void RegisterType(Type key, object item)
        {
            try
            {
                _items.Add(key, item);
            }
            catch (ArgumentException ex)
            {
                throw new ContainerRegisterTypeException(string.Format("Type '{0}' is already registered: '{0}' - '{1}'", key, this[key].GetType()), ex);
            }
        }
        #endregion

        #region Fields (private)
        private readonly TContainerItemCreator _containerItemCreator;

        private readonly TContainerItemCreatorParameters _containerItemCreatorParameters;

        private readonly Dictionary<Type, object> _items;

        private readonly TypeCriteria _typeSearchCriteria;
        #endregion

        #region IContainer Properties
        public int Count
        {
            get
            {
                return _items.Count;
            }
        }

        public object this[Type key]
        {
            get
            {
                if (_items.ContainsKey(key))
                {
                    return _items[key];
                }

                throw new ContainerKeyNotFoundException(string.Format("Key '{0}' is not found", key));
            }
        }
        #endregion

        #region IContainer Methods
        public IEnumerator<Type> GetEnumerator()
        {
            return _items.Keys.GetEnumerator();
        }

        public void RegisterType(Type key, Type value)
        {
            RegisterType(key, _containerItemCreator.Create(value, _containerItemCreatorParameters));
        }

        public virtual void RegisterType(Type key)
        {
            RegisterType(key, key);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion

        #region Properties (protected)
        protected TContainerItemCreator ContainerItemCreator
        {
            [DebuggerStepThrough]
            get
            {
                return _containerItemCreator;
            }
        }

        protected TContainerItemCreatorParameters ContainerItemCreatorParameters
        {
            [DebuggerStepThrough]
            get
            {
                return _containerItemCreatorParameters;
            }
        }

        protected Dictionary<Type, object> Items
        {
            [DebuggerStepThrough]
            get
            {
                return _items;
            }
        }

        protected TypeCriteria TypeSearchCriteria
        {
            get
            {
                return _typeSearchCriteria;
            }
        }
        #endregion
    }
}
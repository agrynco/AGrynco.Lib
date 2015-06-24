#region Usings
using System;
using System.Diagnostics;
using System.Reflection;

using AGrynco.Lib.Containers;
#endregion

namespace AGrynco.Lib.Validation
{
    /// <summary>
    /// Build a collection of validators
    /// </summary>
    /// <typeparam name="TValidatorCreator"></typeparam>
    /// <typeparam name="TValidatorCreatorParameters"></typeparam>
    public abstract class RootValidatorBase<TValidatorCreator,
                                            TValidatorCreatorParameters>
        where TValidatorCreatorParameters : IContainerItemCreatorParameters
        where TValidatorCreator : IContainerItemCreator<TValidatorCreatorParameters>,
            new()
    {
        #region Fields (private)
        private readonly ContainerBase<TValidatorCreator, TValidatorCreatorParameters, ContainerItemRegistrator>
            _container;

        private ValidatorMetaInfoList _metaInfo;
        #endregion

        #region Constructors
        public RootValidatorBase()
        {
            _container = new ContainerBase<TValidatorCreator, TValidatorCreatorParameters,
                ContainerItemRegistrator>(new TypeCriteria(AssembliesToScan,
                                                           new[]
                                                               {
                                                                   FilterByAttributeType
                                                               }),
                                          ContainerItemCreatorParameters);
            BuildMetaInfo();
        }
        #endregion

        #region Methods (private)
        private void BuildMetaInfo()
        {
            _metaInfo = new ValidatorMetaInfoList();
            foreach (Type type in _container)
            {
                object[] attribute = type.GetCustomAttributes(FilterByAttributeType, true);
                Trace.Assert(attribute.Length == 1);
                _metaInfo.Add(new ValidatorMetaInfo((ValidatorAttribute) attribute[0],
                                                    (IValidator) _container[type]));
            }
        }

        private void FillValidator(IValidator validator)
        {
            IValidator[] validators = _metaInfo.GetValidatorsByParent(validator.GetType());
            foreach (IValidator childValidator in validators)
            {
                validator.AddChild(childValidator);
                FillValidator(childValidator);
            }
        }
        #endregion

        #region Methods (protected)
        protected IValidator[] Build()
        {
            IValidator[] result = _metaInfo.GetValidatorsByParent(null);
            foreach (IValidator validator in result)
            {
                FillValidator(validator);
            }
            return result;
        }
        #endregion

        #region Properties (protected)
        protected abstract Assembly[] AssembliesToScan { get; }
        protected abstract TValidatorCreatorParameters ContainerItemCreatorParameters { get; }
        protected abstract Type FilterByAttributeType { get; }
        #endregion
    }
}
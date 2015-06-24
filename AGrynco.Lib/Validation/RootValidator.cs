#region Usings
using System;
using System.Diagnostics;
using System.Reflection;

using AGrynco.Lib.Containers;
#endregion

namespace AGrynco.Lib.Validation
{
    /// <summary>
    /// Root container of IValidator.
    /// </summary>
    public class RootValidator :
        RootValidatorBase<ContainerItemCreator, ItemCreatorParamsEmpty>
    {
        #region Fields (private)
        private readonly IValidator[] _validators;
        #endregion

        #region Constructors
        public RootValidator()
        {
            _validators = Build();
        }
        #endregion

        #region Methods (public)
        public ValidationResultList Validate(IValidated validatedObject)
        {
            ValidationResultList result = new ValidationResultList();
            for (int index = 0; index < _validators.Length; index++)
            {
                result.AddRange(_validators[index].Validate(validatedObject));
            }
            return result;
        }
        #endregion

        #region Properties (public)
        public IValidator[] Validators
        {
            [DebuggerStepThrough]
            get { return _validators; }
        }
        #endregion

        #region Properties (protected)
        protected override Assembly[] AssembliesToScan
        {
            get
            {
                return new[]
                           {
                               Assembly.GetAssembly(GetType())
                           };
            }
        }

        protected override ItemCreatorParamsEmpty ContainerItemCreatorParameters
        {
            get { return null; }
        }

        protected override Type FilterByAttributeType
        {
            get { return typeof (ValidatorAttribute); }
        }
        #endregion
    }
}
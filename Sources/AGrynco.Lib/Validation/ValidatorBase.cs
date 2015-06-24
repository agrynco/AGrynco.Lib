#region Usings
using System;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace AGrynco.Lib.Validation
{
    /// <summary>
    /// Represent a single root validator with child validators
    /// </summary>
    /// <typeparam name="TValidatedObj"><see cref="TValidatedObj"/></typeparam>
    /// <typeparam name="TValidationResult"><see cref="TValidationResult"/></typeparam>
    public abstract class ValidatorBase<TValidatedObj, TValidationResult> : IValidator
        where TValidatedObj : IValidated
        where TValidationResult : IValidationResult
    {
        #region Fields (private)
        private readonly Dictionary<Type, ValidatorBase<TValidatedObj, TValidationResult>> _childItems;
        #endregion

        #region Constructors
        protected ValidatorBase()
        {
            _childItems = new Dictionary<Type, ValidatorBase<TValidatedObj, TValidationResult>>();
        }
        #endregion

        #region IValidator Properties
        public IValidator this[Type key]
        {
            get { return _childItems[key]; }
        }
        #endregion

        #region IValidator Methods
        void IValidator.AddChild(IValidator validator)
        {
            AddChild((ValidatorBase<TValidatedObj, TValidationResult>) validator);
        }

        IValidationResult[] IValidator.Validate(IValidated validatedObject)
        {
            ValidationResultList<object, TValidationResult> validationResults = Validate((TValidatedObj) validatedObject);
            return validationResults.Cast<IValidationResult>().ToArray();
        }
        #endregion

        #region Abstract Methods
        /// <summary>
        /// Validates validatedObj with one rule. For every rule should be declared another type
        /// ancestor of <see cref="ValidatorBase{TValidatedObj,TValidationResult}"/>
        /// </summary>
        /// <param name="validatedObj">Object tovlidate. Should be ancested from <see cref="IValidated"/></param>
        /// <returns>Result of validation - <see cref="TValidatedObj"/> </returns>
        protected abstract TValidationResult DoValidate(TValidatedObj validatedObj);
        #endregion

        #region Methods (public)
        public void AddChild(ValidatorBase<TValidatedObj, TValidationResult> validator)
        {
            _childItems.Add(validator.GetType(), validator);
        }

        /// <summary>
        /// Validate <see cref="validatedObj">with all cild validators</see>/>
        /// </summary>
        /// <param name="validatedObj">Object to validate (<see cref="IValidated"/>)</param>
        /// <returns><see cref="ValidationResultList{TValidatedObject,TValidationResult}"/></returns>
        public ValidationResultList<object, TValidationResult> Validate(TValidatedObj validatedObj)
        {
            ValidationResultList<object, TValidationResult> result =
                new ValidationResultList<object, TValidationResult>();
            TValidationResult validationResult = DoValidate(validatedObj);
            result.Add(validationResult);
            if (validationResult.IsValid)
            {
                foreach (ValidatorBase<TValidatedObj, TValidationResult> validator in _childItems.Values)
                {
                    result.AddRange(validator.Validate(validatedObj));
                }
            }
            return result;
        }
        #endregion
    }
}
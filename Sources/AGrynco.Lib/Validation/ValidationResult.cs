#region Usings
using System;
using System.Reflection;
#endregion

namespace AGrynCo.Lib.Validation
{
    public class ValidationResult<TValidatedObject> : BaseClass, IValidationResult
    {
        #region Fields (private)
        private bool _isValid;
        #endregion

        #region Properties (public)
        public TValidatedObject ValidatedObject { get; set; }
        #endregion

        #region Methods (public)
        public ValidationResult<TValidatedObject> Assign<TOtherValidationObject>(ValidationResult<TOtherValidationObject> validationResult)
        {
            IsValid = validationResult.IsValid;
            ValidationMessage = validationResult.ValidationMessage;

            if (typeof(TValidatedObject) == typeof(object))
            {
                PropertyInfo propertyInfo = GetType().GetProperty("ValidatedObject");
                propertyInfo.SetValue(this, validationResult.ValidatedObject, null);
            }
            else
            {
                throw new NotImplementedException();
            }

            return this;
        }
        #endregion

        #region Constructors
        public ValidationResult()
            : this(false, default(TValidatedObject), null)
        {
        }

        public ValidationResult(bool isValid, TValidatedObject validatedObject, string validationMessage)
        {
            _isValid = isValid;
            ValidatedObject = validatedObject;
            ValidationMessage = validationMessage;
        }
        #endregion

        #region IValidationResult Properties
        public bool IsValid
        {
            get
            {
                return _isValid;
            }
            set
            {
                _isValid = value;
            }
        }

        object IValidationResult.ValidatedObject
        {
            get
            {
                return ValidatedObject;
            }
            set
            {
                ValidatedObject = (TValidatedObject)value;
            }
        }

        public string ValidationMessage { get; set; }
        #endregion
    }
}
#region Usings
using System;
#endregion

namespace AGrynCo.Lib.Validation
{
    public abstract class EasyValidatorBase<TValidatedObject> : IEasyValidator<ValidationResult<TValidatedObject>, TValidatedObject>
    {
        #region Fields (private)
        private readonly string _validationMessage;
        #endregion

        #region Constructors
        public EasyValidatorBase(string validationMessage)
        {
            _validationMessage = validationMessage;
        }
        #endregion

        #region IEasyValidator<ValidationResult<TValidatedObject>,TValidatedObject> Properties
        public string ValidationMessage
        {
            get
            {
                return _validationMessage;
            }
        }
        #endregion

        #region Abstract Methods
        protected abstract bool DoValidate(TValidatedObject obj);
        #endregion

        #region IEasyValidator<ValidationResult<TValidatedObject>,TValidatedObject> Methods
        public ValidationResult<TValidatedObject> Validate(TValidatedObject obj)
        {
            try
            {
                ValidationResult<TValidatedObject> validationResult = new ValidationResult<TValidatedObject>(DoValidate(obj), obj, ValidationMessage);

                //if (!validationResult.IsValid)
                //{
                //    Logger.Info(GetType(), string.Format("Validation result is '{0}'", validationResult));
                //}

                return validationResult;
            }
            catch (Exception ex)
            {
                //Logger.Error(this, ex);
                throw;
            }
        }

        IValidationResult IEasyValidator.Validate(object obj)
        {
            return Validate((TValidatedObject)obj);
        }
        #endregion
    }
}
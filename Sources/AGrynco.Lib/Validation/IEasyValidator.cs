#region Usings
#endregion

namespace AGrynCo.Lib.Validation
{
    public interface IEasyValidator
    {
        #region Abstract Methods
        IValidationResult Validate(object obj);
        #endregion

        #region Properties (public)
        string ValidationMessage { get; }
        #endregion
    }

    public interface IEasyValidator<TValidationResult, TValidatedObject> : IEasyValidator
        where TValidationResult : IValidationResult
    {
        #region Abstract Methods
        TValidationResult Validate(TValidatedObject obj);
        #endregion
    }
}
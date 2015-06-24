#region Usings
using System;
#endregion

namespace AGrynco.Lib.Validation
{
    public interface IValidator
    {
        #region Abstract Methods
        void AddChild(IValidator validator);
        IValidationResult[] Validate(IValidated validatedObject);
        #endregion

        #region Properties (public)
        IValidator this[Type key] { get; }
        #endregion
    }
}
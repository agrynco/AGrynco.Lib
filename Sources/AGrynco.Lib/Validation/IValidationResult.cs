#region Usings
#endregion

#region Usings
#endregion

namespace AGrynCo.Lib.Validation
{
    public interface IValidationResult
    {
        #region Properties (public)
        bool IsValid { get; }
        object ValidatedObject { get; set; }
        string ValidationMessage { get; set; }
        #endregion
    }
}
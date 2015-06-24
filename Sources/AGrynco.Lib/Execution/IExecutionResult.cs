#region Usings
using System;
#endregion

namespace AGrynco.Lib.Execution
{
    public interface IExecutionResult
    {
        #region Properties (public)
        object ActionResult { get; }
        Int64 DurationInTicks { get; }
        DateTime Start { get; }
        #endregion
    }
}
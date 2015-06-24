#region Usings
using System;
#endregion

namespace AGrynco.Lib.Execution
{
    public class ExecutionResult<TActionResult> : BaseClass, IExecutionResult
    {
        #region Constructors
        public ExecutionResult(long durationInTicks, DateTime start, TActionResult actionResult)
        {
            DurationInTicks = durationInTicks;
            Start = start;
            ActionResult = actionResult;
            DurationAsTimeSpan = new TimeSpan(durationInTicks);
        }
        #endregion

        #region Properties (public)
        public TActionResult ActionResult { get; private set; }
        #endregion

        #region IExecutionResul Properties
        object IExecutionResult.ActionResult
        {
            get
            {
                return ActionResult;
            }
        }

        public long DurationInTicks { get; private set; }

        public TimeSpan DurationAsTimeSpan { get; private set; }

        public DateTime Start { get; private set; }
        #endregion
    }
}
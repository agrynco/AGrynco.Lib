#region Usings
using System;
#endregion

namespace AGrynco.Lib.Execution
{
    public static class Executor
    {
        #region Static Methods (public)
        public static ExecutionResult<TResult> Execute<TResult>(Func<TResult> function)
        {
            long initialTicksCount = DateTime.Now.Ticks;
            DateTime startExecution = DateTime.Now;

            TResult executionResult = function.Invoke();
            
            return new ExecutionResult<TResult>(DateTime.Now.Ticks - initialTicksCount, startExecution, executionResult);
        }
        #endregion
    }
}
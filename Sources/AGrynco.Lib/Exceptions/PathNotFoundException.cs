#region Usings

#region Usings
using System;
#endregion

namespace AGrynCo.Lib.Exceptions
{
    #endregion

    public class PathNotFoundException : Exception
    {
        #region Constructors
        public PathNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
        #endregion
    }
}
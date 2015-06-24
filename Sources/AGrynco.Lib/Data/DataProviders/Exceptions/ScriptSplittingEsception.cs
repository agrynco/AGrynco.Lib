#region Usings
using System;
using System.Runtime.Serialization;
#endregion

namespace AGrynco.Lib.Data.DataProviders.Exceptions
{
    public class ScriptSplittingEsception : DataProviderException
    {
        #region Constructors
        public ScriptSplittingEsception()
        {
        }

        public ScriptSplittingEsception(string message)
            : base(message)
        {
        }

        public ScriptSplittingEsception(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected ScriptSplittingEsception(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
        #endregion
    }
}
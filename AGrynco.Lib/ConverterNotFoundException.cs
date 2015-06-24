#region Usings
using System;
#endregion

namespace AGrynco.Lib
{
    public class ConverterNotFoundException : Exception
    {
        #region Constructors
        public ConverterNotFoundException(Type conversionResultType)
            : base(String.Format("Cannot find converter to type \"{0}\"", conversionResultType))
        {
        }
        #endregion
    }
}
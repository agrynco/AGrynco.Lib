#region Usings
using System;
using System.Runtime.Serialization;
#endregion

namespace AGrynCo.Lib.Settings.Exceptions
{
    public class RegistrySettingsException : SettingsException
    {
        #region Constructors
        public RegistrySettingsException()
        {
        }

        public RegistrySettingsException(string message) : base(message)
        {
        }

        public RegistrySettingsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RegistrySettingsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
        #endregion
    }
}
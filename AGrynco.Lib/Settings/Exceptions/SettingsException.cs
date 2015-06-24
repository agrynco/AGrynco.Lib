#region Usings
using System;
using System.Runtime.Serialization;
#endregion

namespace AGrynco.Lib.Settings.Exceptions
{
    public class SettingsException : Exception
    {
        #region Constructors
        public SettingsException()
        {
        }

        public SettingsException(string message) : base(message)
        {
        }

        public SettingsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SettingsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
        #endregion
    }
}
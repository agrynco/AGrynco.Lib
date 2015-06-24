#region Usings
using System;
using System.Runtime.Serialization;
#endregion

namespace AGrynco.Lib.Settings.Exceptions
{
    public class ThereIsNoSettingException : SettingsException
    {
        #region Constructors
        public ThereIsNoSettingException(string key) : base(string.Format("There is no setting with key=\"{0}\"",
                                                                          key))
        {
        }

        public ThereIsNoSettingException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ThereIsNoSettingException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
        #endregion
    }
}
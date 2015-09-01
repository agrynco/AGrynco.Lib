#region Usings
using System;
using System.Runtime.Serialization;
#endregion

namespace AGrynCo.Lib.Settings.Exceptions
{
    public class WrongFormatException : SettingsException
    {
        #region Constructors
        public WrongFormatException(string settingKey, string settingString)
            : this(settingKey, settingString, null)
        {
        }

        public WrongFormatException()
        {
        }

        public WrongFormatException(string message) : base(message)
        {
        }

        public WrongFormatException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public WrongFormatException(string settingKey, string settingString, Exception innerException)
            : base(string.Format("Wrong format of setting key='{0}', value='{1}'.", settingKey, settingString),
                   innerException)
        {
        }

        protected WrongFormatException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
        #endregion
    }
}
namespace AGrynco.Lib.Settings.Exceptions
{
    public class ThereIsNoValueForSettingException : SettingsException
    {
        #region Constructors
        public ThereIsNoValueForSettingException(string settingKey) : base(string.Format("There is no value for setting with key = '{0}'",
                                                                                         settingKey))
        {
        }
        #endregion
    }
}
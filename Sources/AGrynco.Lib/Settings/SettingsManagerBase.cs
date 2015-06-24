namespace AGrynco.Lib.Settings
{
    public abstract class SettingsManagerBase : ISettingsManager
    {
        #region ISettingsManager Methods
        public abstract string GetAppSetting(string key);

        public abstract string GetConnectionString(string key);
        #endregion

        #region Properties (public)
        /// <summary>
        /// Gets value of key by it's full path
        /// </summary>
        /// <param name="key">Full path include name of key</param>
        /// <returns>Value of <see cref="key" />parameter</returns>
        public string this[string key]
        {
            get { return GetAppSetting(key); }
        }
        #endregion
    }
}
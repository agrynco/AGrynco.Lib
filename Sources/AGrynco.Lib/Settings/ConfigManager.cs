#region Usings
using System.Configuration;
#endregion

namespace AGrynCo.Lib.Settings
{
    public static class ConfigManager
    {
        #region Static Methods (public)
        public static string GetAppSettings(string key)
        {
            return GetAppSettings(key, true);
        }

        public static string GetAppSettings(string key, bool isRequired)
        {
            string result = ConfigurationManager.AppSettings[key];

            if (string.IsNullOrEmpty(result) && isRequired)
            {
                throw new ConfigurationErrorsException(string.Format("Can not find key '{0}' in configuration file or value is empty", key));
            }

            return result;
        }

        public static string GetConnectionString(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
        #endregion
    }
}
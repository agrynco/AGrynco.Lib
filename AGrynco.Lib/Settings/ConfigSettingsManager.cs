#region Usings
using System.Configuration;
#endregion

namespace AGrynco.Lib.Settings
{
    internal class ConfigSettingsManager : SettingsManagerBase
    {
        #region Methods (public)
        public override string GetAppSetting(string key)
        {
            string result = ConfigurationManager.AppSettings[key];

            return result;
        }

        public override string GetConnectionString(string key)
        {
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings[key];
            if (connectionStringSettings != null)
            {
                return connectionStringSettings.ConnectionString;
            }

            return null;
        }
        #endregion
    }
}
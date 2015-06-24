#region Usings
using Microsoft.Win32;
#endregion

namespace AGrynco.Lib.Settings
{
    public class RegistrySettingsManager : SettingsManagerBase
    {
        #region Constants
        private const string _DEFAULT_VALUE = "{F959CE2A-539D-4860-A615-D32390DCE9C7}";
        #endregion

        #region Fields (private)
        private readonly string _rootPath;
        #endregion

        #region Constructors
        public RegistrySettingsManager(string rootPath)
        {
            _rootPath = rootPath;
        }
        #endregion

        #region Methods (public)
        public override string GetAppSetting(string key)
        {
            return GetValue(_rootPath, "AppSettings", key, null);
        }

        public override string GetConnectionString(string key)
        {
            return GetValue(_rootPath, "ConnectionStrings", key, null);
        }
        #endregion

        #region Methods (private)
        private string GetValue(string rootPath, string subSection, string key, string defaultValue)
        {
            string keyName = string.Format("{0}\\{1}", rootPath, subSection);
            string value = (string) Registry.GetValue(keyName, key, _DEFAULT_VALUE);

            if (value == null) // There is no key
            {
                //throw new RegistrySettingsException(string.Format("The key {0}\\{1} is not found", keyName, key));
                return defaultValue;
            }

            return IsDefaultValue(value) ? defaultValue : value;
        }

        private bool IsDefaultValue(string value)
        {
            return string.IsNullOrEmpty(value) || value == _DEFAULT_VALUE;
        }
        #endregion
    }
}
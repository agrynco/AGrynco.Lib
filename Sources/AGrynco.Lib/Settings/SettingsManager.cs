#region Usings
using System;
using System.Collections.Generic;
using System.Configuration;

using AGrynco.Lib.Settings.Exceptions;
using AGrynco.Lib.StrUtils.FromStringConverter;
using AGrynco.Lib.StrUtils.FromStringConverter.Exceptions;
#endregion

namespace AGrynco.Lib.Settings
{
    /// <summary>
    /// Wrapper for <see cref="ConfigurationManager"/>. Implemented for 
    /// posibility to log every query to settings and! some settings can be stored
    /// in registry of a computer, so the settings related to developer's environment
    /// should not be placed in a configuration file (<see cref="RegisterSettingsManager"/>).
    /// </summary>
    public class SettingsManager : BaseSingletone<SettingsManager>
    {
        #region Constants
        private const string _DEFAULT_VALUE = "059B003C-43E5-4304-B53E-FDFE0D8596C3";
        #endregion

        #region Constructors
        private SettingsManager()
        {
            _settingsManagers = new List<ISettingsManager>();
            _configSettingsManager = new ConfigSettingsManager();

            RegisterSettingsManager(CreateRegistrySettingsManager());
            RegisterSettingsManager(_configSettingsManager);
        }
        #endregion

        #region Fields (private)
        private readonly ConfigSettingsManager _configSettingsManager;

        private readonly List<ISettingsManager> _settingsManagers;
        #endregion

        #region Methods (public)
        public string GetAppSetting(string key)
        {
            return GetAppSetting<string>(key, true);
        }

        public TSetting GetAppSetting<TSetting>(string settingKey)
        {
            return GetAppSetting<TSetting>(settingKey, true);
        }

        public TSetting GetAppSetting<TSetting>(string settingKey, bool isMandatory)
        {
            if (settingKey == null)
            {
                throw new ArgumentNullException("settingKey");
            }

            string asStringValue = GetAppSetting(settingKey, _DEFAULT_VALUE);

            if (asStringValue != _DEFAULT_VALUE)
            {
                return CastSetting<TSetting>(settingKey, asStringValue);
            }
            else if (isMandatory)
            {
                throw new ConfigurationErrorsException(string.Format("The settingKey ('{0}') is not found in all configurations", settingKey));
            }

            return default(TSetting);
        }

        public TSetting GetAppSetting<TSetting>(string key, TSetting defaultValue)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("key");
            }

            string settingString = DoGetAppSetting(key);

            if (settingString == null)
            {
                return defaultValue;
            }

            return CastSetting<TSetting>(key, settingString);
        }

        public string GetConnectionString(string key)
        {
            foreach (ISettingsManager settingsManager in _settingsManagers)
            {
                string appSetting = settingsManager.GetConnectionString(key);
                if (appSetting != null)
                {
                    return appSetting;
                }
            }

            throw new ThereIsNoSettingException(key);
        }
        #endregion

        #region Methods (private)
        private TSetting CastSetting<TSetting>(string key, string value)
        {
            try
            {
                return FromStringConverter.Convert<TSetting>(value);
            }
            catch (FromStringConvertException exception)
            {
                throw new SettingsException(string.Format("Can not parse setting with key = \"{0}\" value = \"{1}\"", key, value), exception);
            }
        }

        private RegistrySettingsManager CreateRegistrySettingsManager()
        {
            return new RegistrySettingsManager(_configSettingsManager.GetAppSetting("registryApplicationRoot"));
        }

        private string DoGetAppSetting(string key)
        {
            foreach (ISettingsManager settingsManager in _settingsManagers)
            {
                string appSetting = settingsManager.GetAppSetting(key);
                if (appSetting != null)
                {
                    return appSetting;
                }
            }

            return null;
        }

        private void RegisterSettingsManager(ISettingsManager settingsManager)
        {
            _settingsManagers.Add(settingsManager);
        }
        #endregion
    }
}
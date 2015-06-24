namespace AGrynco.Lib.Settings
{
    public interface ISettingsManager
    {
        #region Abstract Methods
        string GetAppSetting(string key);
        string GetConnectionString(string key);
        #endregion
    }
}
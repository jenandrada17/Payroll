using System.Configuration;

namespace DBConnect.Settings
{
    public class AppSettings
    {
        private readonly Configuration _config;

        public AppSettings()
        {
            _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        }

        public string GetConnectionString(string key)
        {
            return _config.ConnectionStrings.ConnectionStrings[key].ConnectionString;
        }

        public void SaveConnectionString(string key, string value)
        {
            _config.ConnectionStrings.ConnectionStrings[key].ConnectionString = value;
            _config.ConnectionStrings.ConnectionStrings[key].ProviderName = "FirebirdSql.Data.FirebirdClient";
            _config.Save(ConfigurationSaveMode.Modified);
        }
    }
}
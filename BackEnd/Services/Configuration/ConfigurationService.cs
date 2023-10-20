namespace BackEnd.Services.Configuration
{
    public class ConfigurationService : IConfigurationService
    {
        public string ConnectionString => GeConnectionString();

       
        public string GeConnectionString()
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build().Get<Configuration>();

            return configuration.ConnectionStrings.database;
        }
    }

    #region ConfigModel

    public class Configuration
    {
        public LoggingConfig Logging { get; set; }
        public string AllowedHosts { get; set; }
        public ConnectionStringsConfig ConnectionStrings { get; set; }
    }

    public class LoggingConfig
    {
        public LogLevelConfig LogLevel { get; set; }
    }

    public class LogLevelConfig
    {
        public string Default { get; set; }
        public string MicrosoftAspNetCore { get; set; }
    }

    public class ConnectionStringsConfig
    {
        public string database { get; set; }
    }
    #endregion
}


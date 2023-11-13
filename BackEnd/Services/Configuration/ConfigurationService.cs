namespace BackEnd.Services.Configuration
{
    public class ConfigurationService : IConfigurationService
    {
        public string ConnectionString => GeConnectionString();
        public JwtConfiguration Jwt => GetJwt();


        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddSingleton(cfg => cfg.GetRequiredService<IOptions<ConfigurationService>>().Value);
        //}

        public string GeConnectionString()
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build().Get<Configuration>();

            return configuration.ConnectionStrings.database;
        }


        public JwtConfiguration GetJwt()
        {
            
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build().Get<Configuration>();

            configuration.Jwt = new JwtConfiguration() //del 
            {
                 Issuer = "mohamadlawand.com",
                Audience = "mohamadlawand.com",
                Key = "ijurkbdlhmklqacwqzdxmkkhvqowlyqa"
            };
            return configuration.Jwt;
        }
    }

    #region ConfigModel

    public class Configuration
    {
   
        public LoggingConfig Logging { get; set; }
        public string AllowedHosts { get; set; }
        public ConnectionStringsConfig ConnectionStrings { get; set; }
        public JwtConfiguration Jwt;
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



    public class JwtConfiguration
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Key { get; set; }
    }
    #endregion
}


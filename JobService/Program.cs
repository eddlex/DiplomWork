using BackEnd.Services.Configuration;
using BackEnd.Services.Db;
using JobService;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddSingleton<IConfigurationService, ConfigurationService>();
      //  services.AddSingleton<IDbService, IDbService>();
    })
    .Build();


await host.RunAsync();
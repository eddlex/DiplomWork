using BackEnd.Services.Configuration;
using BackEnd.Services.Db;
using FrontEnd.API;
using FrontEnd.Interface;
using JobService;
using ConfigurationService = BackEnd.Services.Configuration.ConfigurationService;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<DbBackUpWorker>();
        services.AddHostedService<LogBackUpWorker>();
    })
    .Build();


await host.RunAsync();
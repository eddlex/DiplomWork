using BackEnd.Services.Configuration;
using BackEnd.Services.Db;
using JobService;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<DbBackUpWorker>();
    })
    .Build();


await host.RunAsync();
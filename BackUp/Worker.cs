// using BackEnd.Services.Configuration;

namespace BackUp;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    
    // public string GeConnectionString()
    // {
    //     var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build().Get<Configuration>();
    //     return configuration.ConnectionStrings.database;
    // }
    
    
    
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        
        
        
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time} , ConnectionString: {GeConnectionString}", DateTimeOffset.Now, "sd");
            await Task.Delay(1000 , stoppingToken);
        }
    }
    
    

}
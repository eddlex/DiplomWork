using BackEnd.Services.Configuration;
using BackEnd.Services.Db;

namespace JobService;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IConfigurationService configurationService;
    public IDbService dbService { get; set; }


    public Worker(ILogger<Worker> logger,
        IConfigurationService configurationService
    )
    {
        _logger = logger;
        this.configurationService = configurationService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            
             _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
             await BackUp();
             // _logger.LogInformation("Connection String: {string}", configurationService.GeConnectionString());
            await Task.Delay(1000, stoppingToken);
        }
    }


    public async Task BackUp()
    {
        string backupFilePath = "C:\\Users\\eduard.ordukhanyan\\source\\repos\\eddlex\\DiplomWork\\JobService\\Db\\a.bak";


        // Check if the backup file exists
        if (!File.Exists(backupFilePath))
        {
            Console.WriteLine("Backup file does not exist.");
            return;
        }
        try
        {
             dbService = new DbService(this.configurationService);
             
             var cmd = dbService.CreateCommand();
             cmd.CommandTimeout = 60 * 60 ;
             cmd.CommandText = $"USE master; " +
                               $"ALTER DATABASE [db_aa56f4_diplom] SET SINGLE_USER WITH ROLLBACK IMMEDIATE; " +
                               $"RESTORE DATABASE [db_aa56f4_diplom] FROM DISK = '{backupFilePath}' WITH REPLACE";
             await cmd.ExecuteNonQueryAsync();
            
             Console.WriteLine("Database restore completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred: {ex.Message}");
        }
    }
}
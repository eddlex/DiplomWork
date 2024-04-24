using System.Net;

namespace JobService;

public class DbBackUpWorker : BackgroundService
{
    private readonly ILogger<DbBackUpWorker> _logger;
    
    public DbBackUpWorker(ILogger<DbBackUpWorker> logger
    )
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            
             _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
              BackUp();
             // _logger.LogInformation("Connection String: {string}", configurationService.GeConnectionString());
            await Task.Delay(1000 * 60 * 60 * 24, stoppingToken);
        }
    }


 
    private  void BackUp()
    {
        // Check if the backup file exists
        if (!Directory.Exists("BackUp"))
        {
            Directory.CreateDirectory("BackUp");
        }
        
        try
        {
            string ftpServerUrl = "ftp://diplom23024-001@win5141.site4now.net/";
            string username = "diplom23024-001";
            string password = "123123Aa";
            
            // FTP file path to download
            var file = $"db_aa7bdf_diplom_{DateTime.Now.Month}_{DateTime.Now.Day}_{DateTime.Now.Year}.bak";
            var path = "db/";
            //ftp://diplom23024-001@win5141.site4now.net/db/db_aa7bdf_diplom_4_21_2024.bak
            // Local file path to save the downloaded file
            string localFilePath = @$"BackUp/{file}";

            // Create FTP request
            var ftpRequest = (FtpWebRequest)WebRequest.Create(ftpServerUrl + path + file);
            ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
            ftpRequest.Credentials = new NetworkCredential(username, password);
            
            // Get FTP response
            using (var ftpResponse = (FtpWebResponse)ftpRequest.GetResponse())
            using (var responseStream = ftpResponse.GetResponseStream())
            using (var fileStream = new FileStream(localFilePath, FileMode.Create))
            {
                // Copy FTP file contents to local file
                responseStream.CopyTo(fileStream);
            }     
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred: {ex.Message}");
        }
    }
}
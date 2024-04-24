using System.Net;
using BackEnd.Models.Input;
using BackEnd.Models.Output;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace JobService;

public class LogBackUpWorker : BackgroundService
{
    private readonly ILogger<LogBackUpWorker> _logger;
    public HttpClient HttpClient { get; set; }


    public LogBackUpWorker(ILogger<LogBackUpWorker> logger)
    {
        this._logger = logger;
        this.HttpClient = new HttpClient();

    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
             _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
             await BackUp();
             await Task.Delay(1000 * 60 * 60 * 24, stoppingToken);
        }
    }


 
    private  async Task  BackUp()
    {
        // Check if the backup file exists
        if (!Directory.Exists("Log"))
        {
            Directory.CreateDirectory("Log");
        }
        
        try
        {
            var files = GetAllLogNames();
            var model = new LogPost
            {
                Date = files.Count > 0 ? DateTime.UtcNow : null
            };
           

            var result = await Execute<List<Log>, LogPost>(model);

            foreach (var e in result)
            {
                CreateFileWithBase64Content("Log", e.Name, e.Data);
            }
           
            
            
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred: {ex.Message}");
        }
    }
    
    
    static void CreateFileWithBase64Content(string directory, string filename, string base64Content)
    {
        // Decode base64 content
        byte[] content = Convert.FromBase64String(base64Content);

        // Combine directory and filename
        string filePath = Path.Combine(directory, filename);

        try
        {
            // Check if the file exists
            if (File.Exists(filePath))
            {
                // Delete the existing file
                File.Delete(filePath);
            }

            // Write content to file
            File.WriteAllBytes(filePath, content);
            Console.WriteLine($"File '{filename}' created or replaced with base64 content in '{directory}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
    
    private List<string> GetAllLogNames(string directory = "Log")
    {
        try
        {
            return Directory.GetFiles(directory).ToList().Where(r => r.Contains("log")).Select(r => Path.GetFileName(r)).ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            return new List<string>();
        }
    }
    
    public async Task<T1?> Execute<T1, T2>(T2? requestBody = default)
    {
        try
        {
            var url = "https://localhost:7154/LogDownloader";


            
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(url)
            };

          
            request.Headers.Add("Accept", "application/json");
            
            request.Content = new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json");
            
            var response = await this.HttpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
               
              
                var r  = JsonConvert.DeserializeObject<T1>(result);
                return r;
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                var parsedJson = JsonSerializer.Deserialize<Dictionary<string, string>>(await response.Content.ReadAsStringAsync());
                if (parsedJson != null && parsedJson.TryGetValue("ErrorMessage", out var extractedValue))
                {
                    throw new Exception(extractedValue);
                }
            }
          
            throw new Exception("error from back");
        }
        catch (Exception ex)
        {
            //if (++failedAttempts >= 3 && ex.Message == "UserName or password is wrong")
            //    await js.InvokeVoidAsync("setLinkRed");
            //return false;
            throw new Exception(ex.Message);
        }
    }
}
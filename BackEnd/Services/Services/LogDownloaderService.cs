using BackEnd.Models.Input;
using BackEnd.Services.Interfaces;
using BackEnd.Models.Output;
using MudBlazor;

namespace BackEnd.Services.Services;
public class LogDownloaderService : ILogDownloaderService
{
    public LogDownloaderService(){}

    public async Task<List<Log>> GetLog(LogPost model)
    {
        var result = new List<Log>();
        if (model.Date.HasValue)
        { 
            result.Add(await LogToBase64(model.Date.Value));
        }
        else
        {
            var name = GetAllLogNames();
            foreach (var n in name)
            {
                var s = await LogToBase64(null, n);
                result.Add(s);
            }
        }
        return result;
    }
    
    private async Task<Log> LogToBase64(DateTime? date,  string name = FilterOperator.String.Empty)
    {
        var filename = date.HasValue ? "log_" + date.Value.Year + "_" + date.Value.Month + "_" + date.Value.Day + ".txt" : name;
        var filePath = Path.Combine("Log", filename);
        var fileBytes = await File.ReadAllBytesAsync(filePath);
        var base64Content = Convert.ToBase64String(fileBytes);
        return new()
        {
            Name = filename,
            Data = base64Content
        };
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
}

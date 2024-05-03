using BackEnd.Services.Db;
using BackEnd.Helpers;
using Dapper;
using BackEnd.Models.Input.Delete;
using BackEnd.Models.Input.Post;
using BackEnd.Models.Input.Put;
using BackEnd.Services.Interfaces;
using BackEnd.Models.Output;
using FrontEnd.Helpers;
using System.Diagnostics;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Reflection;

namespace BackEnd.Services.Services;

public class SuggestionService : ISuggestionService
{
    private readonly DbService dbService;

    public (int UserId, int DepartmentId, int RoleId) Token { get; set; }

    public SuggestionService(IDbService dbService,
        IHttpContextAccessor httpContextAccessor)
    {
        this.dbService = (DbService)dbService;
        if (httpContextAccessor.HttpContext != null)
            this.Token = httpContextAccessor.HttpContext.User.ParseToken();
    }

    public string ExecutePythonScript(string scriptName, string arguments = "")
    {
        scriptName = Directory.GetCurrentDirectory().Replace("BackEnd", @"ML" + Extensions.GetPathSlashType() + scriptName);

        ProcessStartInfo processStartInfo = new ProcessStartInfo();

        processStartInfo.FileName = "python3";

        string argumentString = scriptName + " " + arguments;
        processStartInfo.Arguments = argumentString;

        processStartInfo.RedirectStandardOutput = true;  // Redirect the output
        processStartInfo.UseShellExecute = false;  // Run the process without shell
        processStartInfo.CreateNoWindow = true;  // Don't create a console window

        Process process = new Process();
        process.StartInfo = processStartInfo;
        process.Start();

        string output = process.StandardOutput.ReadToEnd();

        process.WaitForExit();

        return output;
    }
    
    public async Task<List<Suggestion>?> GetSuggestions()
    {
        var res = (await dbService.QueryAsync<Suggestion>("spGetSuggestions", new {}))
            .ToList();
        return res;
    }
    
    public async Task<List<Suggestion>?> GetSimilars(int? suggId = null)
    {
        var scriptName = "similar.py";
        var argumentsString = "";
        if (suggId != null)
        { argumentsString = suggId.ToString();}

        var result = await Task.Run(() => ExecutePythonScript(scriptName, argumentsString));

        //var similarSentences = JsonConvert.DeserializeObject<Dictionary<int, (int, string)>>(result);

      
        var similarSentences = JsonSerializer.Deserialize<Dictionary<int, (int, string)>>(result);

        var similarList = new List<Suggestion>();

        foreach (var kvp in similarSentences)
        {
            Suggestion sgg = new Suggestion
            {
                Id = kvp.Key,
                FormIdentificationId = kvp.Value.Item1,
                Value = kvp.Value.Item2
            };

            similarList.Add(sgg);
        }

        return similarList;
    }

    public async Task<bool> Delete(int id)
    {
        var res = await dbService.QueryAsync<bool>("spDeleteSuggestion", new { Id = id });
        return res.FirstOrDefault();
    }
}




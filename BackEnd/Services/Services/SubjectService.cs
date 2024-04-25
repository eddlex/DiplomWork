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

namespace BackEnd.Services.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly DbService dbService;

        public (int UserId, int DepartmentId, int RoleId) Token { get; set; }

        public SubjectService(IDbService dbService,
            IHttpContextAccessor httpContextAccessor)
        {
            this.dbService = (DbService)dbService;
            if (httpContextAccessor.HttpContext != null)
                this.Token = httpContextAccessor.HttpContext.User.ParseToken();
        }

        // change to another dir
        public string ExecutePythonScript(string scriptPath, string arguments)
        {
            // Create a new Process
            ProcessStartInfo processStartInfo = new ProcessStartInfo();

            // Set the Python executable path and the script path
            processStartInfo.FileName = "python3";  // Use "python3" if necessary

            // Combine script path and arguments into a single string
            //string argumentString = $"{scriptPath} {string.Join(" ", arguments)}";
            string argumentString = scriptPath + " " + arguments;
            processStartInfo.Arguments = argumentString;

            // Set other process start options
            processStartInfo.RedirectStandardOutput = true;  // Redirect the output
            processStartInfo.UseShellExecute = false;  // Run the process without shell
            processStartInfo.CreateNoWindow = true;  // Don't create a console window

            // Start the process
            Process process = new Process();
            process.StartInfo = processStartInfo;
            process.Start();

            // Capture the output
            string output = process.StandardOutput.ReadToEnd();

            // Wait for the process to exit
            process.WaitForExit();

            // Return the output
            return output;
        }

        public async Task<List<SubjectOptimized>> GetOptimizedHours(int hours, List<int> ids)
        {
            string fileName = @"schedule.py";
            //string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            //string scriptPath = Path.Combines(baseDirectory, "schedule.py");

            string argumentsString = hours.ToString() + " " + string.Join(" ", ids);
            //string result = ExecutePythonScript(scriptPath, new string[] { argumentsString });
            var filePath = Directory.GetCurrentDirectory().Replace("BackEnd", "ML/" + fileName);
            string result = await Task.Run(() => ExecutePythonScript(filePath, argumentsString));
              //   /Users/eduardordukhanyan/RiderProjects/DiplomWork/BackEnd
            Dictionary<int, double> optimizedHoursDict = JsonSerializer.Deserialize<Dictionary<int, double>>(result);

            List<SubjectOptimized> optimizedList = new List<SubjectOptimized>();

            foreach (var kvp in optimizedHoursDict)
            {
                SubjectOptimized subjectOptimized = new SubjectOptimized
                {
                    Id = kvp.Key, 
                    Hour = kvp.Value 
                };

                optimizedList.Add(subjectOptimized);
            }

            return optimizedList;
        }

        public async Task<List<Subject>> GetSubjects(int? id)
        {
            if (Token.RoleId < 2 && id != Token.DepartmentId)
                throw Alert.Create(Constants.Error.WrongPermissions);
            var res = (await dbService.QueryAsync<Subject>("spGetSubjects", new { RoleId = Token.RoleId, DepartmentId = id }))
                .ToList();
            return res;
        }
        
        public async Task<Subject?> AddSubject(SubjectPost model)
        {
            var res = await dbService.QueryAsync<Subject>("spAddSubject", model);
            return res.FirstOrDefault();
        }

        public async Task<bool?> DeleteSubject(SubjectDelete model)
        {
            if (Token.DepartmentId != model.DepartmentId && Token.RoleId < 2)
                throw Alert.Create(Constants.Error.WrongPermissions);

            var res = await dbService.QueryAsync<bool?>("spDeleteSubject", new { Id = model.Id });
            return res.FirstOrDefault();
        }

        public async Task<Subject?> EditSubject(SubjectPut model)
        {
            var res = (await dbService.QueryAsync<Subject>("spEditSubject", model)).FirstOrDefault();
            return res;
        }


    }
}

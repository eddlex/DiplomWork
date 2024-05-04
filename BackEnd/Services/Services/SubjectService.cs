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
using BackEnd.Models.Input;

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

        public string ExecutePythonScript(string scriptName, string arguments="")
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

        public async Task<List<bool>> TrainModel()
        {
            string scriptName = "create_model.py";

            string res = await Task.Run(() => ExecutePythonScript(scriptName));

            var resList = new List<bool> { !res.StartsWith("Traceback") };
            return resList;
              
        }

        public async Task<List<bool>> EvaluateModel()
        {
            string scriptName = "evaluate.py";

            string res = await Task.Run(() => ExecutePythonScript(scriptName));

            var resList = new List<bool> { !res.StartsWith("Traceback") };
            return resList;

        }

        public async Task<List<SubjectOptimized>> GetOptimizedHours(int sheduleId)
        {
            var scriptName = "schedule.py";
            var argumentsString = sheduleId.ToString();
            
            var result = await Task.Run(() => ExecutePythonScript(scriptName, argumentsString));
            var optimizedHoursDict = JsonSerializer.Deserialize<Dictionary<int, double>>(result);

            var optimizedList = new List<SubjectOptimized>();

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



        public async Task<List<Schedule?>> GetSubjectSchedules()
        {
            var res = (await dbService.QueryAsync<Schedule>("spGetSubjectsSchedulesCalculations", new
            {
                Token.RoleId,
                Token.DepartmentId
            })).ToList();
            return res;
        }
        
        public async Task<Schedule?> AddSubjectSchedules(SchedulePost model)
        {
            var res = (await dbService.QueryAsync<Schedule>("spAddSubjectScheduleCalculation", model)).FirstOrDefault();

            if (res == default)
                Alert.Create(Constants.Error.SomethingWrong);
            return res;
        }
        
        
        public async Task<Schedule?> EditSubjectSchedules(SchedulePut model)
        {
            var res = (await dbService.QueryAsync<Schedule>("spEditSubjectScheduleCalculation", model)).FirstOrDefault();

            if (res == default)
                Alert.Create(Constants.Error.SomethingWrong);
            return res;
        }
    }
}

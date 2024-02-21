using BackEnd.Services.Db;
using BackEnd.Services.Interfaces;
using Dapper;
using System.Data;
using BackEnd.Helpers;
using BackEnd.Models.Input;
using BackEnd.Models.Output;
using FrontEnd.Helpers;
using static BackEnd.Helpers.Enums;

namespace BackEnd.Services.Services
{
    public class SmtpService : ISmtpService
    {
        private readonly DbService dbService;
        public (int UserId, int DepartmentId, int RoleId) Token { get; set; }
        public SmtpService(IDbService dbService,
                           IHttpContextAccessor httpContextAccessor)
        {
            this.dbService = (DbService)dbService;
            if (httpContextAccessor.HttpContext != null)
                this.Token = httpContextAccessor.HttpContext.User.ParseToken();
        }

        public async Task<SmtpConfig> EditSmtpConfig(SmtpConfigPut model)
        {
            if (Token.RoleId == 0 ||
                Token.RoleId == 1 && Token.DepartmentId != model.DepartmentId)
                throw Alert.Create(Constants.Error.WrongPermissions);
            var result = (await this.dbService.QueryAsync<SmtpConfig>("spEditSmtpConfiguration", model)).FirstOrDefault();

            if (result is null)
                throw Alert.Create(Constants.Error.SomethingWrong);
            
            return result;
        }

        public async Task<int> DeleteSmtpConfig(SmtpConfigDelete model)
        {
            if (Token.RoleId == 0 ||
                Token.RoleId == 1 && Token.DepartmentId != model.DepartmentId)
                throw Alert.Create(Constants.Error.WrongPermissions);
            
            var result = (await dbService.QueryAsync<int?>("spDeleteSmtpConfiguration", new { model.Id })).FirstOrDefault();

            if (!result.HasValue)
                throw Alert.Create(Constants.Error.SomethingWrong);
           
            return result.Value;
        }

        public async Task<List<SmtpConfig>> GetSmtpConfig()
        {
            var result = await dbService.QueryAsync<SmtpConfig?>("spGetSmtpConfigurations",
            new {
                Token.RoleId,
                Token.DepartmentId    
            });
            return result.ToList();

        }
    }

    //public class SmtpConfig
    //{
    //    public int Id { get; set; }
    //    public int DepatmentId { get; }
    //    public string? SmtpServer { get; set; }
    //    public int Port { get; set; }
    //    public string? Username { get; set; }
    //    public string? Password { get; set; }
    //    public bool? EnableSSL { get; set; }
    //}
}

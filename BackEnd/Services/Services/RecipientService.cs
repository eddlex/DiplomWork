using BackEnd.Services.Db;
using System.Data;
using BackEnd.Helpers;
using Dapper;
using BackEnd.Models.Input;
using BackEnd.Services.Interfaces;
using BackEnd.Models.Output;
using FrontEnd.Helpers;

namespace BackEnd.Services.Services
{
    public class RecipientService : IRecipientService
    {
        private readonly DbService dbService;

        public (int UserId, int DepartmentId, int RoleId) Token { get; set; }

        public RecipientService(IDbService dbService,
                                IHttpContextAccessor httpContextAccessor)
        {
            this.dbService = (DbService)dbService;
            if (httpContextAccessor.HttpContext != null)
                this.Token = httpContextAccessor.HttpContext.User.ParseToken();
        }

        public async Task<List<Recipient>> GetRecipients()
        {
            var res = (await dbService.QueryAsync<Recipient>("spGetRecipients", new { Token.RoleId, Token.DepartmentId })).ToList();
            return res;
        }



        public async Task<int?> DeleteRecipient(Recipient model) //tested
        {
            if (Token.RoleId == 0 ||
                Token.RoleId == 1 && Token.DepartmentId != model.DepartmentId)
                throw Alert.Create(Constants.Error.WrongPermissions);
            
            var res = (await dbService.QueryAsync<int>("spDeleteRecipient", new{model.Id})).FirstOrDefault();
            return res;
        }
        
        public async Task<Recipient?> AddRecipient(Recipient model)
        {
            var res = (await dbService.QueryAsync<Recipient>("spAddRecipient", 
                new
                {
                    model.Name,
                    model.Mail,
                    model.DepartmentId,
                    model.GroupId,
                    model.Description
                })).FirstOrDefault();

            if (res == default)
                throw Alert.Create(Constants.Error.SomethingWrong);
            return res;
        }
        
        
        public async Task<Recipient?> EditRecipient(Recipient model)
        {
            if (Token.RoleId == 0 ||
               Token.RoleId == 1 && Token.DepartmentId != model.DepartmentId)
                throw Alert.Create(Constants.Error.WrongPermissions);
            var res = (await dbService.QueryAsync<Recipient>("spEditRecipient", model)).FirstOrDefault();
            
            if (res == default)
                throw Alert.Create(Constants.Error.SomethingWrong);
            return res;
        }

















        #region Recipient Groups
        public async Task<List<RecipientGroupGet?>> GetRecipientGroups(int? Id = null)
        {
            return (await dbService.QueryAsync<RecipientGroupGet>("spGetRecipientGroups", new { Id, Token.RoleId, Token.DepartmentId })).ToList();
        }

        public async Task<RecipientGroup?> AddRecipientGroup(RecipientGroupPost model)
        {
            var result = (await dbService.QueryAsync<RecipientGroup>("spAddRecipientGroup", model)).FirstOrDefault();
            if (result is null)
               throw Alert.Create(Constants.Error.SomethingWrong);
            return result;

        }      
     
        public Task<bool> DelRecipientGroups(List<int> ides)
        {
            throw new NotImplementedException();
        }
        
        public Task<bool> UpdateRecipientGroups(List<RecipientGroupPut> groups)
        {
            throw new NotImplementedException();
        }
        
        #endregion
        
        
 


        public async Task<List<MailBody>> GetMailBody()
        {
            using var connection = dbService.CreateConnection();

            return (await connection.QueryAsync<MailBody>("spGetMailBody",
                                                           new { Token.DepartmentId },
                                                           commandType: CommandType.StoredProcedure)).ToList();
        }


        public async Task<bool> DelMailBody(int id)
        {
            using var cmd = dbService.CreateCommand();
            cmd.CommandText = "spDelMailBody";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Id", id);

            return await cmd.ExecuteNonQueryAsync() > 0;
        }


        public async Task<bool> UpdateMailBody(MailBodyPut input)
        {
            using var cmd = dbService.CreateCommand();
            cmd.CommandText = "spUpdateMailBody";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Id", input.Id);
            cmd.Parameters.AddWithValue("Name", input.Name);
            cmd.Parameters.AddWithValue("Subject", input.Subject);
            cmd.Parameters.AddWithValue("Body", input.Body);
            cmd.Parameters.AddWithValue("DepartmentId", input.UniversityId);

            return await cmd.ExecuteNonQueryAsync() > 0;
        }

    }
}

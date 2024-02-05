using BackEnd.Services.Db;
using System.Data;
using BackEnd.Helpers;
using Dapper;
using BackEnd.Models.Input;
using BackEnd.Services.Interfaces;
using BackEnd.Models.Output;

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

        public async Task<List<RecipientGroupGet>> GetRecipientGroups(int? Id = null)
        {
            using var connection = dbService.CreateConnection();

            return (await connection.QueryAsync<RecipientGroupGet>("spGetRecipientGroups", new { Id }, commandType: CommandType.StoredProcedure)).ToList();
        }


        public async Task<bool> AddRecipientGroups(List<RecipientGroupGet> groups)
        {
            using var cmd = dbService.CreateCommand();
            cmd.CommandText = "spAddRecipientGroups";
            cmd.CommandType = CommandType.StoredProcedure;

            var dt = new DataTable("Items");
            dt.Columns.Add(new DataColumn("Item1", typeof(string)));
            dt.Columns.Add(new DataColumn("Item2", typeof(string)));

            foreach (var group in groups)
            {
                dt.Rows.Add(group.Name, group.Description);
            }

            var param = cmd.Parameters.Add("@Items", SqlDbType.Structured);
            param.TypeName = "dbo.StringTuple";
            param.Value = dt;
            return await cmd.ExecuteNonQueryAsync() > 0;
        }


        public async Task<bool> DelRecipientGroups(List<int> ides)
        {
            using var cmd = dbService.CreateCommand();
            cmd.CommandText = "spDelRecipientGroups";
            cmd.CommandType = CommandType.StoredProcedure;

            var dt = new DataTable("Ides");
            dt.Columns.Add(new DataColumn("Id", typeof(int)));


            foreach (var id in ides)
            {
                dt.Rows.Add(id);
            }

            var param = cmd.Parameters.Add("@Ides", SqlDbType.Structured);
            param.TypeName = "dbo.Ides";
            param.Value = dt;
            return await cmd.ExecuteNonQueryAsync() > 0;
        }

        public async Task<bool> UpdateRecipientGroups(List<RecipientGroupPut> groups)
        {
            using var cmd = dbService.CreateCommand();
            cmd.CommandText = "spUpdateRecipientGroups";
            cmd.CommandType = CommandType.StoredProcedure;

            var dt = new DataTable("dbo.IntStringStringTripl");
            dt.Columns.Add(new DataColumn("item1", typeof(int)));
            dt.Columns.Add(new DataColumn("item2", typeof(string)));
            dt.Columns.Add(new DataColumn("item3", typeof(string)));


            foreach (var group in groups)
            {
                dt.Rows.Add(group.Id, group.Name, group.Description);
            }

            var param = cmd.Parameters.Add("@Groups", SqlDbType.Structured);
            param.TypeName = "dbo.IntStringStringTriple";
            param.Value = dt;
            return await cmd.ExecuteNonQueryAsync() > 0;
        }


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

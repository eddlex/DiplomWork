using BackEnd.Services.Db;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Data.SqlClient;
using Dapper;
using BackEnd.Models.Input;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BackEnd.Services.Form
{
    public class RecipientService : IRecipientService
    {
        private readonly DbService dbService;
        public RecipientService(IDbService dbService)
        {
            this.dbService = (DbService)dbService;
        }

        public async Task<List<RecipientGroup>> GetRecipientGroups(int? Id = null)
        {
            using var connection = this.dbService.CreateConnection();

            return  (await connection.QueryAsync<RecipientGroup>("spGetRecipientGroups", new { Id = Id }, commandType: CommandType.StoredProcedure)).ToList();  
        }


        public async Task<bool> AddRecipientGroups(List<RecipientGroup> groups)
        {    
            using var cmd = this.dbService.CreateCommand();
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
            return (await cmd.ExecuteNonQueryAsync()) > 0;
        }

    }
}

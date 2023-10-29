using BackEnd.Services.Db;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Data.SqlClient;
using Dapper;
using BackEnd.Models.Input;

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


    }
}

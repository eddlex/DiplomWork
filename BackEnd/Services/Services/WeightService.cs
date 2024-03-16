using BackEnd.Models.Input;
using BackEnd.Services.Db;
using BackEnd.Services.Interfaces;
using Dapper;
using System.Data;
using BackEnd.Helpers;
using BackEnd.Models.Output;
using FrontEnd.Helpers;

namespace BackEnd.Services.Services
{
    public class WeightService : IWeightService
    {
        private readonly DbService dbService;
        public WeightService(IDbService dbService)
        {
            this.dbService = (DbService)dbService;
        }

        public async Task<List<Weight?>> GetWeights()
        {
            var weights = (await dbService.QueryAsync<Weight>("spGetWeights")).ToList(); 
          
            if (weights == null || !weights.Any())
                throw Alert.Create(Constants.Error.NotExistAnyWeight);
            
            return weights;
        }

        public async Task<bool> AddWeight(WeightPost weight)
        {
            await using var cmd = dbService.CreateCommand();
            cmd.CommandText = "spAddDepartment"; //change
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Name", weight.Name);
            cmd.Parameters.AddWithValue("@Value", weight.Value);

            return Convert.ToBoolean(await cmd.ExecuteNonQueryAsync());
        }


        public async Task<bool> DelWeight(int id)
        {
            using var cmd = dbService.CreateCommand();
            cmd.CommandText = "spDelWeight"; 
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", id);

            return Convert.ToBoolean(await cmd.ExecuteNonQueryAsync());
        }
    }
}

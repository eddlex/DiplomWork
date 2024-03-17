using BackEnd.Services.Db;
using System.Data;
using BackEnd.Helpers;
using BackEnd.Models.Input;
using BackEnd.Models.Input.Post;
using BackEnd.Models.Output;
using BackEnd.Services.Interfaces;
using FrontEnd.Helpers;
using MudBlazor;

namespace BackEnd.Services.Services
{
    public class RatingService : IRatingService
    {
        private readonly DbService dbService;
      
        public RatingService(IDbService dbService)
        {
            this.dbService = (DbService)dbService;
        }
        
        public async Task<List<RatingView?>> GetRatingsView(string id)
        {
            
            if (Guid.TryParse(id, out Guid guid))
            {
                var result = await this.dbService.QueryAsync<RatingView>("spGetRatingsView", new {id = guid});
                return result.ToList();
            }

            return new();
        }


   
    }
}

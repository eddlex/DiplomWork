using BackEnd.Models.Output;

namespace BackEnd.Services.Interfaces
{
    public interface IRatingService
    {
        Task<List<RatingView?>> GetRatingsView(string id);
      
    }
}
using BackEnd.Models.Input;
using BackEnd.Models.Output;

namespace BackEnd.Services.Interfaces
{
    public interface IWeightService
    {
        Task<List<Weight?>> GetWeights();
        Task<bool> AddWeight(WeightPost weight);
        Task<bool> DelWeight(int id);
    }
}

using BackEnd.Models.Output;

namespace BackEnd.Services.Interfaces;

public interface ISuggestionService
{
    public Task<List<Suggestion>?> GetSuggestions(); 
    public Task<List<int>?> GetSimilars(double threshold, int? id);
    public Task<bool> Delete(int id);    
}
using BackEnd.Models.Output;

namespace BackEnd.Services.Interfaces;

public interface ISuggestionService
{
    public Task<List<Suggestion>?> GetSuggestions(); 
    public Task<List<Suggestion>?> GetSimilars(int? id = null);
    public Task<bool> Delete(int id);    
}
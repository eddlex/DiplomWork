using FrontEnd.Model;

namespace FrontEnd.Interface;

public interface ISuggestionService
{
    public Task<List<Suggestion>?> GetSuggestions(); 
    public Task<List<Suggestion>?> GetSimilars(int? id = null);
    public Task<bool> Delete(int id);    
}
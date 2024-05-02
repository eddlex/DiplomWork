using System.Runtime.CompilerServices;
using FrontEnd.Helpers;
using FrontEnd.Interface;
using FrontEnd.Model;
using FrontEnd.Pages;

namespace FrontEnd.API;

public class SuggestionService :  BaseService, ISuggestionService
{
    public SuggestionService(IHttpService httpService) : base(httpService, "Suggestion")
    {
    }
    public async Task<List<Suggestion>?> GetSuggestions()
    {
       var suggestions =  await this.Get<Suggestion>();
       if (suggestions is null or { Count: 0 })
       {
           throw Helpers.Alert.Create(Constants.Error.NotExistAnyDepartment);
       }

       return suggestions;
    }
    
    public async Task<List<Suggestion>?> GetSimilars(int? suggId = null)
    {
        //var session = await this.GetSession() ?? throw Helpers.Alert.Create(Constants.Error.SessionNotFound);
        var result = await this.Get<Suggestion>(id: suggId, method: "Similars");
        return result;
    }

    public async Task<bool> Delete(int id)
    {
        var session = await this.GetSession() ?? throw Helpers.Alert.Create(Constants.Error.SessionNotFound);
        if (session.RoleId != 2 )
            throw Helpers.Alert.Create(Constants.Error.WrongPermissions);

        var result = await this.Delete<bool, int>(id);
        return result;
    }
}




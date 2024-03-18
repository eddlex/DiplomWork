using FrontEnd.Interface;
using FrontEnd.Model.BL;

namespace FrontEnd.API;

public class RatingService : BaseService, IRatingService
{
    public RatingService(IHttpService httpService) : base(httpService, "Rating")
    {
    }

    public async Task<List<RatingViewBl>> GetRatingsView(string model)
    {
       var result =  await this.Get<RatingViewBl>(model);
       return result ?? new();
    }
}
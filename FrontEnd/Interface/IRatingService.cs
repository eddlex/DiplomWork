using FrontEnd.Model.BL;

namespace FrontEnd.Interface;

public interface IRatingService
{
    Task<List<RatingViewBl>> GetRatingsView(string model);

}
using BackEnd.Models.Input;
using BackEnd.Services.Interfaces;
using BackEnd.Services.Services;
using Microsoft.AspNetCore.Mvc;


namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RatingController : ControllerBase
    {
        private readonly RatingService ratingService;
        public RatingController(IRatingService formService)
        {
            this.ratingService = (RatingService)formService;
        }

        
        [HttpGet]
        public async Task<ActionResult<List<Models.Output.RatingView>>> Rating(string id)
        {
            return Ok(await this.ratingService.GetRatingsView(id));
        }
        
        [HttpPost]
        public async Task<ActionResult<bool>> Rating(RatingPost model)
        {
            return Ok(await this.ratingService.AddRatings(model));
        }
        
        
        
    }
}
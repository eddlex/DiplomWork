using BackEnd.Models.Input;
using BackEnd.Models.Output;
using BackEnd.Services.Interfaces;
using BackEnd.Services.Services;
using Microsoft.AspNetCore.Authorization;
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
        
    }
}
using BackEnd.Models.Input.Delete;
using BackEnd.Models.Input.Post;
using BackEnd.Models.Input.Put;
using BackEnd.Models.Output;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SuggestionController : ControllerBase
    {
        private readonly ISuggestionService suggestionService;
        public SuggestionController(ISuggestionService suggestionService)
        {
            this.suggestionService = suggestionService;
        }


        [Route("Similars")]
        [HttpGet]
        public async Task<ActionResult<List<Suggestion>>> Similars()
        {
            return Ok(await this.suggestionService.GetSimilars());
        }



        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<List<Suggestion>>> Suggestion()
        {
            return Ok(await this.suggestionService.GetSuggestions());
        }
        
        [HttpDelete]
        //[Authorize]
        public async Task<ActionResult<bool>> Suggestion(int id)
        {
            return Ok(await this.suggestionService.Delete(id));
        }
        
    } 
}
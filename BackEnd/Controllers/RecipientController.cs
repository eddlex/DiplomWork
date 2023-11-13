using BackEnd.Models.Input;
using BackEnd.Services.Interfaces;
using BackEnd.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipientController : ControllerBase
    {
        private readonly RecipientService recipientService;
        public RecipientController(IRecipientService recipientService)
        {
            this.recipientService = (RecipientService)recipientService;
        }

        [Route("Groups/{Id:int}")]
        [HttpGet]
        public async Task<ActionResult<List<RecipientGroupGet>>> GetRecipientGroups(int Id)
        {
            return Ok(await this.recipientService.GetRecipientGroups(Id));
        }

        [Route("Groups")]
        [HttpGet]
        public async Task<ActionResult<List<RecipientGroupGet>>> GetRecipientGroups()
        {
            return Ok(await this.recipientService.GetRecipientGroups());
        } 

        [Route("Groups")]
        [HttpPost]
        public async Task<ActionResult<bool>> AddRecipientGroups(List<RecipientGroupGet> Groups)
        {
            return Ok(await this.recipientService.AddRecipientGroups(Groups));
        }

        [Route("Groups")]
        [HttpDelete]
        public async Task<ActionResult<bool>> DelRecipientGroups(List<int> Ides)
        {
            return Ok(await this.recipientService.DelRecipientGroups(Ides)); 
        }

        [Route("Groups/{Id:int}")]
        [HttpDelete]
        public async Task<ActionResult<bool>> DelRecipientGroups(int Id)
        {
            return Ok(await this.recipientService.DelRecipientGroups(new List<int> { Id }));
        }

        [Route("Groups")]
        [HttpPut]
        public async Task<ActionResult<bool>> UpdateRecipientGroups(List<RecipientGroupPut> groups)
        {
            return Ok(await this.recipientService.UpdateRecipientGroups(groups));
        }
    }; 
}
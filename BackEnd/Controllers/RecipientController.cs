using BackEnd.Helpers;
using BackEnd.Models.Input;
using BackEnd.Models.Output;
using BackEnd.Services.Interfaces;
using BackEnd.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipientController : ControllerBase
    {
        private readonly IRecipientService recipientService;
        public RecipientController(IRecipientService recipientService)
        {
            this.recipientService = recipientService;
        }
        
        [HttpGet]     //tested
        public async Task<ActionResult<List<Recipient>>> Recipient()
        {
            return Ok(await this.recipientService.GetRecipients());
        }
        
        [HttpPost]  //tested
        public async Task<ActionResult<Recipient>> Recipient(Recipient input)
        {
            return Ok(await this.recipientService.AddRecipient(input));
        }
        
        [HttpDelete]
        public async Task<ActionResult<int?>> RecipientDelete(Recipient model)
        {
            return Ok(await this.recipientService.DeleteRecipient(model));
        }
        [HttpPut] //tested
        public async Task<ActionResult<int?>> RecipientEdit(Recipient model)
        {
            return Ok(await this.recipientService.EditRecipient(model));
        }
        
        
        
        [Route("Group")] //tested
        [HttpGet]
        public async Task<ActionResult<List<RecipientGroupGet>>> RecipientGroup()
        {
            return Ok(await this.recipientService.GetRecipientGroups());
        }
        
        [Route("Group")] 
        [HttpPost]
        public async Task<ActionResult<RecipientGroup>> RecipientGroup(RecipientGroupPost model)
        {
            return Ok(await this.recipientService.AddRecipientGroup(model));
        }
        
        [Route("Group")] 
        [HttpDelete]
        public async Task<ActionResult<int>> RecipientGroup(RecipientGroupDelete model)
        {
            return Ok(await this.recipientService.DeleteRecipientGroup(model));
        }
        
        [Route("Group")] 
        [HttpPut]
        public async Task<ActionResult<RecipientGroup>> RecipientGroup(RecipientGroupPut model)
        {
            return Ok(await this.recipientService.EditRecipientGroup(model));
        }
        
        
        
        /*
        [Route("Groups/{Id:int}")]
        [HttpGet]
        public async Task<ActionResult<List<RecipientGroupGet>>> GetRecipientGroups(int Id)
        {
            return Ok(await this.recipientService.GetRecipientGroups(Id));
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

        [Route("MailBody")]
        [HttpGet]
        public async Task<ActionResult<bool>> GetMailBody()
        {
            this.recipientService.Token = User.ParseToken();
            return Ok(await this.recipientService.GetMailBody());
        }*/

    }; 
}
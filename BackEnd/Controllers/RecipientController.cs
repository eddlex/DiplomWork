using BackEnd.Models.Input;
using BackEnd.Services.Form;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using System.Web.Http.Description;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

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


        [ResponseType(typeof(List<RecipientGroup>))]
        [Route("Groups/{Id:int}")]
        [HttpGet]
        public async Task<ActionResult<List<RecipientGroup>>> GetRecipientGroups(int Id)
        {
            return Ok(await this.recipientService.GetRecipientGroups(Id));
        }


        [ResponseType(typeof(List<RecipientGroup>))]
        [Route("Groups")]
        [HttpGet]
        public async Task<ActionResult<List<RecipientGroup>>> GetRecipientGroups()
        {
            return Ok(await this.recipientService.GetRecipientGroups());
        }



    }; 
}
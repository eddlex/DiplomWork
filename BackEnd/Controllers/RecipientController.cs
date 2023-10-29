using BackEnd.Models.Input;
using BackEnd.Services.Form;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
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


        [ResponseType(typeof(List<RecipientGroupGet>))]
        [Route("Groups/{Id:int}")]
        [HttpGet]
        public async Task<ActionResult<List<RecipientGroupGet>>> GetRecipientGroups(int Id)
        {
            return Ok(await this.recipientService.GetRecipientGroups(Id));
        }


        [ResponseType(typeof(List<RecipientGroupGet>))]
        [Route("Groups")]
        [HttpGet]
        public async Task<ActionResult<List<RecipientGroupGet>>> GetRecipientGroups()
        {
            return Ok(await this.recipientService.GetRecipientGroups());
        } 
        
        [ResponseType(typeof(bool))]
        [Route("Groups")]
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<ActionResult<bool>> AddRecipientGroups(List<RecipientGroupGet> Groups)
        {
            return Ok(await this.recipientService.AddRecipientGroups(Groups));
        }


        [ResponseType(typeof(bool))]
        [Route("Groups")]
        [Microsoft.AspNetCore.Mvc.HttpDelete]
        public async Task<ActionResult<bool>> DelRecipientGroups(List<int> Ides)
        {
            return Ok(await this.recipientService.DelRecipientGroups(Ides)); 
        }

        [ResponseType(typeof(bool))]
        [Route("Groups/{Id:int}")]
        [Microsoft.AspNetCore.Mvc.HttpDelete]
        public async Task<ActionResult<bool>> DelRecipientGroups(int Id)
        {
            return Ok(await this.recipientService.DelRecipientGroups(new List<int> { Id }));
        }




        [ResponseType(typeof(bool))]
        [Route("Groups")]
        [Microsoft.AspNetCore.Mvc.HttpPut]
        public async Task<ActionResult<bool>> UpdateRecipientGroups(List<RecipientGroupPut> groups)
        {
            return Ok(await this.recipientService.UpdateRecipientGroups(groups));
        }


    }; 
}
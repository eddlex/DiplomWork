using BackEnd.Models.Input;
using BackEnd.Services.Form;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using System.Web.Http.Description;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FormController : ControllerBase
    {
        private readonly FormService formService;
        public FormController(IFormService formService)
        {
            this.formService = (FormService)formService;
        }


        [ResponseType(typeof(List<Form>))]
        [Route("{GroupId:int}")]
        [HttpGet]
        public async Task<ActionResult<List<Form>>> GetForm(int GroupId)
        {
            return Ok(await this.formService.GetForms(GroupId));
        }


        [ResponseType(typeof(List<Form>))]
        [HttpGet]
        public async Task<ActionResult<List<Form>>> GetForm()
        {
            return Ok(await this.formService.GetForms());
        }



    }; 
}
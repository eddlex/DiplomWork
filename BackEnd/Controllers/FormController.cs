using BackEnd.Services.Interfaces;
using BackEnd.Services.Services;
using Microsoft.AspNetCore.Mvc;


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

        [Route("{GroupId:int}")]
        [HttpGet]
        public async Task<ActionResult<List<Models.Output.Form>>> GetForm(int GroupId)
        {
            return Ok(await this.formService.GetForms(GroupId));
        }

        [HttpGet]
        public async Task<ActionResult<List<Models.Output.Form>>> GetForm()
        {
            return Ok(await this.formService.GetForms());
        }

    }; 
}
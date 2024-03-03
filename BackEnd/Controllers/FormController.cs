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
    public class FormController : ControllerBase
    {
        private readonly FormService formService;
        public FormController(IFormService formService)
        {
            this.formService = (FormService)formService;
        }

        // [Route("{GroupId:int}")]
        // [HttpGet]
        // public async Task<ActionResult<List<Models.Output.Form>>> GetForm(int GroupId)
        // {
        //     return Ok(await this.formService.GetForms(GroupId));
        // }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<Models.Output.Form>>> Form()
        {
            return Ok(await this.formService.GetForms());
        }
        
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<List<Models.Output.Form>>> Form(FormPost model)
        {
            return Ok(await this.formService.AddForm(model));
        }
        
        [HttpDelete]
        [Authorize]
        public async Task<ActionResult<List<Models.Output.Form>>> Form(FormDelete model)
        {
            return Ok(await this.formService.DeleteForm(model));
        }
        
        [HttpPut]
        [Authorize]
        public async Task<ActionResult<List<Models.Output.Form>>> Form(FormPut model)
        {
            return Ok(await this.formService.EditForm(model));
        }
        
        [HttpGet]
        [Authorize]
        [Route("Row")]
        public async Task<ActionResult<List<Models.Output.Form>>> FormRow(int id)
        {
            return Ok(await this.formService.GetFormRows(id));
        }
        
        
        [HttpDelete]
        [Authorize]
        [Route("Row")]
        public async Task<ActionResult<int>> FormRow(FormRowDelete model)
        {
            return Ok(await this.formService.DeleteFormRow(model));
        }

    }; 
}
using BackEnd.Services.Form;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using System.Web.Http.Description;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
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


        [ResponseType(typeof(List<BackEnd.Models.Form.Form>))]
        [HttpPost(Name = nameof(FormController))]
        public IHttpActionResult GetForm([FromBody] int GroupId)
        {
            return (IHttpActionResult)Ok(this.formService.GetForms(GroupId));
        }

        [HttpPut(Name = nameof(FormController))]
        public void SetForm()
        {
              
        }


        [Microsoft.AspNetCore.Mvc.HttpPatch(Name = nameof(FormController))]
        public void PatchUserSmtpConfig()
        {

        }

        [HttpDelete(Name = nameof(FormController))]
        public void DeleteUserSmtpConfig()
        {

        }

    }; 
}
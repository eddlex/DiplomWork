using BackEnd.Services.Form;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UniversityController : ControllerBase
    {
        private readonly FormService universityService;
        public UniversityController(IFormService formService)
        {
            this.universityService = (FormService)formService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Models.Output.University>>> GetUniversities()
        {
            return Ok();
        }


      //  [ResponseType(typeof(List<Models.Output.Form>))]
        [HttpPost]
        public async Task<ActionResult<List<Models.Output.Form>>> GetForm()
        {
            return Ok();
        }



    }; 
}
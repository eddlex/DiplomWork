using BackEnd.Services.Form;
using BackEnd.Services.University;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UniversityController : ControllerBase
    {
        private readonly UniversityService universityService;
        public UniversityController(IUniversityService universityService)
        {
            this.universityService = (UniversityService)universityService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Models.Output.University>>> GetUniversities()
        {
            return Ok(await this.universityService.GetUniversities());
        }


      //  [ResponseType(typeof(List<Models.Output.Form>))]
        [HttpPost]
        public async Task<ActionResult<List<Models.Output.Form>>> GetForm()
        {
            return Ok();
        }



    }; 
}
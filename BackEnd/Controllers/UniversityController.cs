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


        [HttpPost]
        public async Task<ActionResult<List<Models.Output.University>>> AddUniversities(Models.Input.UniversityPost university)
        {
            return Ok(await this.universityService.AddUniversities(university));
        }


        [HttpDelete]
        public async Task<ActionResult<bool>> DelUniversities(int id)
        {
            return Ok(await this.universityService.DelUniversities(id));
        }

    }; 
}
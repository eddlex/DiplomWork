using BackEnd.Helpers;
using BackEnd.Services.Interfaces;
using BackEnd.Services.Services;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<ActionResult<List<Models.Output.University>>> AddUniversity(Models.Input.UniversityPost university)
        {
            return Ok(await this.universityService.AddUniversity(university));
        }


        [HttpDelete]
        public async Task<ActionResult<bool>> DelUniversity(int id)
        {
            return Ok(await this.universityService.DelUniversity(id));
        }

    }; 
}
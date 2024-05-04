using BackEnd.Models.Input.Delete;
using BackEnd.Models.Input.Post;
using BackEnd.Models.Input.Put;
using BackEnd.Models.Output;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using BackEnd.Models.Input;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SemesterController : ControllerBase
    {
        private readonly ISemesterService semesterService;
        public SemesterController(ISemesterService semesterService)
        {
            this.semesterService = semesterService;
        }

        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<List<Semester>>> Semester()
        {
            return Ok(await this.semesterService.GetSemesters());
        }
        
        [HttpPut]
        //[Authorize]
        public async Task<ActionResult<Semester>> Semester(Semester model)
        {
            return Ok(await this.semesterService.EditSemester(model));
        }
    } 
}
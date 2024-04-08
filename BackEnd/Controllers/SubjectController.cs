using BackEnd.Models.Input.Post;
using BackEnd.Models.Input.Put;
using BackEnd.Models.Output;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService subjectService;
        public SubjectController(ISubjectService subjectService)
        {
            this.subjectService = subjectService;
        }
        
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<Subject>>> Subject(int id)
        {
            return Ok(await this.subjectService.GetSubjects(id));
        }
        
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<Subject>>> Subject()
        {
            return Ok(await this.subjectService.GetSubjects());
        }
        
        
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Subject?>> Subject(SubjectPost model)
        {
            return Ok(await this.subjectService.AddSubject(model));
        }
        
        [HttpPut]
        [Authorize]
        public async Task<ActionResult<Subject>> Subject(SubjectPut model)
        {
            return Ok(await this.subjectService.EditSubject(model));
        }
        
    } 
}
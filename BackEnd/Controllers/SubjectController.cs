using BackEnd.Models.Input.Delete;
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
        public async Task<ActionResult<List<Subject>>> Subject(int? id)
        {
            return Ok(await this.subjectService.GetSubjects(id));
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
        
        
        [HttpDelete]
        [Authorize]
        public async Task<ActionResult<bool>> Subject(SubjectDelete model)
        {
            return Ok(await this.subjectService.DeleteSubject(model));
        }
        
    } 
}
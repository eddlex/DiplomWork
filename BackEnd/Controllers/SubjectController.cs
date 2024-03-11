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
        
        // [HttpPost]  //tested
        // public async Task<ActionResult<Recipient>> Recipient(Recipient input)
        // {
        //     return Ok(await this.recipientService.AddRecipient(input));
        // }
        //
        // [HttpDelete]
        // public async Task<ActionResult<int?>> RecipientDelete(Recipient model)
        // {
        //     return Ok(await this.recipientService.DeleteRecipient(model));
        // }
        // [HttpPut] //tested
        // public async Task<ActionResult<int?>> RecipientEdit(Recipient model)
        // {
        //     return Ok(await this.recipientService.EditRecipient(model));
        // }
        //
        
        
        
  
    } 
}
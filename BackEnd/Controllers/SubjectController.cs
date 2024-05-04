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
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService subjectService;
        public SubjectController(ISubjectService subjectService)
        {
            this.subjectService = subjectService;
        }

        [Route("ScheduleRow")]
        [HttpGet]
        public async Task<ActionResult<List<ScheduleRow>>> ScheduleRow(int id)
        {
            return Ok(await this.subjectService.GetSubjectScheduleRows(id));
        }
        
        [Route("ScheduleRow")]
        [HttpPost]
        public async Task<ActionResult<Schedule>> ScheduleRow(ScheduleRowPost model)
        {
            return Ok(await this.subjectService.AddSubjectScheduleRow(model));
        }
        
        [Route("ScheduleRow")]
        [HttpDelete]
        public async Task<ActionResult<bool>> ScheduleRow(ScheduleRowDelete model)
        {
            return Ok(await this.subjectService.DeleteSubjectScheduleRow(model));
        }
        
        
        [Route("Schedule")]
        [HttpGet]
        public async Task<ActionResult<List<Schedule>>> Schedule()
        {
            return Ok(await this.subjectService.GetSubjectSchedules());
        }
        
        [Route("Schedule")]
        [HttpPost]
        public async Task<ActionResult<Schedule>> Schedule(SchedulePost model)
        {
            return Ok(await this.subjectService.AddSubjectSchedules(model));
        }
        
        [Route("Schedule")]
        [HttpPut]
        public async Task<ActionResult<Schedule>> Schedule(SchedulePut model)
        {
            return Ok(await this.subjectService.EditSubjectSchedules(model));
        }
        
        
        
        
        
        
        [Route("Hour")]
        [HttpGet]
        public async Task<ActionResult<List<SubjectOptimized>>> SubjectHours(int hours, [FromQuery]  List<int> ids)
        {
            return Ok(await this.subjectService.GetOptimizedHours(hours, ids));
        }

        [Route("Train")]
        [HttpGet]
        public async Task<ActionResult<List<bool>>> TrainModel()
        {
            return Ok(await this.subjectService.TrainModel());
        }

        [Route("Evaluate")]
        [HttpGet]
        public async Task<ActionResult<List<bool>>> EvaluateModel()
        {
            return Ok(await this.subjectService.EvaluateModel());
        }


        #region Subjects
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
        
        #endregion
    } 
}
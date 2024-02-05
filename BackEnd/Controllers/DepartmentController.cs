using BackEnd.Helpers;
using BackEnd.Services.Interfaces;
using BackEnd.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly DepartmentService departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            this.departmentService = (DepartmentService)departmentService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Models.Output.Department>>> Department()
        {
            return Ok(await this.departmentService.GetDepartments());
        }


        [HttpPost]
        public async Task<ActionResult<List<Models.Output.Department>>> Department(Models.Input.DepartmentPost department)
        {
            return Ok(await this.departmentService.AddDepartment(department));
        }


        [HttpDelete]
        public async Task<ActionResult<bool>> DelUniversity(int id)
        {
            return Ok(await this.departmentService.DelDepartment(id));
        }

    }; 
}
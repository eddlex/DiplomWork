using BackEnd.Models.Input;
using BackEnd.Models.Input.Put;
using BackEnd.Models.Output;
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
        [Authorize]
        public async Task<ActionResult<Department>> Department(Models.Input.DepartmentPost department)
        {
            return Ok(await this.departmentService.AddDepartment(department));
        }


        [HttpDelete]
        [Authorize]
        public async Task<ActionResult<bool>> Department([FromBody] int id)
        {
            return Ok(await this.departmentService.DelDepartment(id));
        }
        
        
        [HttpPut]
        [Authorize]
        public async Task<ActionResult<Department>> Department(DepartmentPut model)
        {
            return Ok(await this.departmentService.EditDepartment(model));
        }

    }; 
}
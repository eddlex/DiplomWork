using BackEnd.Models.Input;
using BackEnd.Models.Output;
using BackEnd.Services.Interfaces;
using BackEnd.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController:ControllerBase //: BaseController
    {
        private readonly UserService userService;
        public UserController(IUserService userService)
        {
            this.userService = (UserService)userService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<bool>> Register(RegistrationPost input)
        {
            return Ok(await this.userService.Register(input));
        }
        
        
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<UserGet>>> User()
        {
            return Ok(await this.userService.GetUsers());
        }

        [HttpDelete]
        [Authorize]
        public async Task<ActionResult<int?>> UserDelete(UserGet model)
        {
            return Ok(await this.userService.DeleteUser(model));
        }
        [HttpPut]
        [Authorize]
        public async Task<ActionResult<int?>> UserEdit(UserGet model)
        {
            return Ok(await this.userService.EditUser(model));
        }

    }; 
}
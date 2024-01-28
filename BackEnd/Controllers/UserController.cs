using BackEnd.Models.Input;
using BackEnd.Services.Interfaces;
using BackEnd.Services.Services;
using Microsoft.AspNetCore.Mvc;


namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService userService;
        public UserController(IUserService userService)
        {
            this.userService = (UserService)userService;
        }

        [Route("Register")]
        [HttpPost]
        public async Task<ActionResult<List<Models.Output.Form>>> Register(RegistrationPost input)
        {
            return Ok(await this.userService.Register(input));
        }
        

    }; 
}
using BackEnd.Models.Input;
using BackEnd.Services.Interfaces;
using BackEnd.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SecurityController : ControllerBase
    {
        private readonly UserService userService;

        public SecurityController(IUserService userService)
        {
            this.userService = (UserService)userService;
        }

        [HttpPost("Authorize")]
      //  [AllowAnonymous]
        public async Task<IActionResult> Authorize(UserPost user)
        {
            return Ok(await userService.GenerateToken(user));
        }




    }
}
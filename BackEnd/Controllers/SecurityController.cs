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
            var a = await userService.GenerateToken(user);
            return Ok(a);
        }



//eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCIsImN0eSI6IkpXVCJ9.eyJVc2VySWQiOiIwIiwiVW5pdmVyc2l0eUlkIjoiMCIsInJvbGUiOiIwIiwianRpIjoiYjNhODI1OTYtZmEwMi00ODg0LTk0YWYtMzQ5ZmY4NzZlYjg0IiwibmJmIjoxNzA2NDM1MzUwLCJleHAiOjE3MDY0Mzg5NTAsImlhdCI6MTcwNjQzNTM1MCwiaXNzIjoibW9oYW1hZGxhd2FuZC5jb20iLCJhdWQiOiJtb2hhbWFkbGF3YW5kLmNvbSJ9.JsPzmihbZG3GZRm4XZWMAXAvaWspFC9Bb8FyKZfEm959OG_58eYFht2ssn2H8bHaCbnanmmv9Wr9Zt2v5EFWDQ" +
          
          
    }
}
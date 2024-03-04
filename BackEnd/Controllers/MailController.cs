using BackEnd.Models.Output;
using BackEnd.Services.Interfaces;
using BackEnd.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MailController : ControllerBase
    {
        private readonly MailService mailService;

        public MailController(IMailService mailService)
        {
            this.mailService = (MailService)mailService;
        }


        [HttpPost]
        [Authorize]
        public async Task<ActionResult<bool>> Mail(Form model)
        {
            return Ok(await mailService.SendMail(model));
        }

    }; 
}
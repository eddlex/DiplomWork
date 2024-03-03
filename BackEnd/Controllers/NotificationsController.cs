using BackEnd.Helpers;
using BackEnd.Models.Output;
using BackEnd.Services.Interfaces;
using BackEnd.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificationsController : ControllerBase
    {
        private readonly MailService mailService;

        public NotificationsController(IMailService mailService)
        {
            this.mailService = (MailService)mailService;
        }


        [HttpPost]
        [Authorize]
        [Route("SendMail")]
        public async Task<ActionResult<bool>> SendForms(Form model)
        {
            return Ok(await mailService.SendMail(model));
        }

    }; 
}
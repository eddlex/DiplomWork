using BackEnd.Services.SMTPConfig;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SmtpController : ControllerBase
    {
        private readonly SmtpService configService;

        public SmtpController(ISmtpService configService)
        {
            this.configService = (SmtpService)configService;
        }


        [Route("{ConfigId:int}")]
        [HttpGet]
        public async Task<ActionResult<SmtpConfig>> GetSmtpConfig(int id)
        {
            return Ok(await this.configService.GetSmtpConfig(id));
        }

        [Route("{ConfigId:int}")]
        [HttpPut]
        public async Task<ActionResult<bool>> UpdateSmtpConfig(SmtpConfig config)
        {
            return Ok(await this.configService.UpdateSmtpConfig(config));
        }

        [Route("{ConfigId:int}")]
        [HttpDelete]
        public async Task<ActionResult<bool>> DelSmtpConfig(int id)
        {
            return Ok(await this.configService.DelSmtpConfig(id));
        }
    }; 
}
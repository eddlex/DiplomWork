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


        [Route("{id:int}")]
        [HttpGet]
        public async Task<ActionResult<SmtpConfig>> GetSmtpConfig(int id)
        {
            return Ok(await this.configService.GetSmtpConfig(id));
        }

        [HttpPut]
        public async Task<ActionResult<bool>> UpdateSmtpConfig(SmtpConfig config)
        {
            return Ok(await this.configService.UpdateSmtpConfig(config));
        }

        [Route("{id:int}")]
        [HttpDelete]
        public async Task<ActionResult<bool>> DelSmtpConfig(int id)
        {
            return Ok(await this.configService.DelSmtpConfig(id));
        }
    }; 
}
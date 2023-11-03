using BackEnd.Models;
using BackEnd.Models.Input;
using BackEnd.Services.Configuration;
using BackEnd.Services.SMTPConfig;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SmtpController : ControllerBase
    {
        private readonly SMTPConfigService configService;

        public SmtpController(ISMTPConfigService configService)
        {
            this.configService = (SMTPConfigService)configService;
        }


        [Route("Smtp/{ConfigId:int}")]
        [HttpGet]
        public async Task<ActionResult<SMTPConfig>> GetConfig(int ConfigId)
        {
            return Ok(await this.configService.GetConfig(ConfigId));
        }

        [Route("Smtp/{ConfigId:int}")]
        [HttpPut]
        public async Task<ActionResult<bool>> UpdateSMTPConfig(SMTPConfig config)
        {
            return Ok(await this.configService.UpdateSMTPConfig(config));
        }

        [Route("Smtp/{ConfigId:int}")]
        [HttpDelete]
        public async Task<ActionResult<bool>> DelSMTPConfig(int ConfigId)
        {
            return Ok(await this.configService.DelSMTPConfig(ConfigId));
        }
    }; 
}
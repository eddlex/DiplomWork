using BackEnd.Helpers;
using BackEnd.Services.Interfaces;
using BackEnd.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Models.Input;
using BackEnd.Models.Output;

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


        [Authorize]
        [HttpGet]
        public async Task<ActionResult<SmtpConfig>> GetSmtpConfig()
        {
            return Ok(await this.configService.GetSmtpConfig(User.ParseToken().UserId));
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult<bool>> UpdateSmtpConfig(SmtpConfigPut config)
        {
            return Ok(await this.configService.UpdateSmtpConfig(User.ParseToken().PermissionId, config));
        }

        [Authorize]
        [Route("{id:int}")]
        [HttpDelete]
        public async Task<ActionResult<bool>> DelSmtpConfig(int id)
        {
            return Ok(await this.configService.DelSmtpConfig(User.ParseToken().PermissionId, id));
        }


        //[Route("{id:int}")]
        //[HttpGet]
        //public async Task<ActionResult<SmtpConfig>> GetSmtpConfig(int id)
        //{
        //    return Ok(await this.configService.GetSmtpConfig(id));
        //}

        //[HttpPut]
        //public async Task<ActionResult<bool>> UpdateSmtpConfig(SmtpConfig config)
        //{
        //    return Ok(await this.configService.UpdateSmtpConfig(config));
        //}

        //[Route("{id:int}")]
        //[HttpDelete]
        //public async Task<ActionResult<bool>> DelSmtpConfig(int id)
        //{
        //    return Ok(await this.configService.DelSmtpConfig(id));
        //}
    };
}
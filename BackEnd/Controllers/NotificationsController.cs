using BackEnd.Helpers;
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
        private readonly NotificationsService notificationsService;

        public NotificationsController(INotificationsService notificationsService)
        {
            this.notificationsService = (NotificationsService)notificationsService;
        }


        [HttpPost]
        [Authorize]
        [Route("SendForms")]
        public async Task<ActionResult<bool>> SendForms(int groupId)
        {
            this.notificationsService.Token = User.ParseToken();
            return Ok(await notificationsService.SendForms(groupId));
        }

    }; 
}
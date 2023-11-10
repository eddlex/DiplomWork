using BackEnd.Services.Form;
using BackEnd.Services.Notification;
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


        [HttpGet]
        public async Task<ActionResult<bool>> Send()
        {
            await notificationsService.SendMessage();
            return Ok(true);
        }

    }; 
}
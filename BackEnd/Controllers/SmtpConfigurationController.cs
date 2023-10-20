using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SmtpConfigurationController : ControllerBase
    {
        public SmtpConfigurationController()
        {
            
        }

        [HttpPost(Name = nameof(SmtpConfigurationController))]
        public void GetUserSmtpConfig()
        {
            
        }

        [HttpPut(Name = nameof(SmtpConfigurationController))]
        public void PutUserSmtpConfig()
        {
              
        }


        [HttpPatch(Name = nameof(SmtpConfigurationController))]
        public void PatchUserSmtpConfig()
        {

        }

        [HttpDelete(Name = nameof(SmtpConfigurationController))]
        public void DeleteUserSmtpConfig()
        {

        }

    }; 
}
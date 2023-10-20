using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FormController : ControllerBase
    {
        
        public FormController()
        {
       
        }

        [HttpPost(Name = nameof(FormController))]
        public void GetForm()
        {
           
        }

        [HttpPut(Name = nameof(FormController))]
        public void SetForm()
        {
              
        }


        [HttpPatch(Name = nameof(FormController))]
        public void PatchUserSmtpConfig()
        {

        }

        [HttpDelete(Name = nameof(FormController))]
        public void DeleteUserSmtpConfig()
        {

        }

    }; 
}
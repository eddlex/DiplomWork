using BackEnd.Models.Input;
using BackEnd.Models.Output;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogDownloaderController : ControllerBase
    {

        private readonly ILogDownloaderService logDownloaderService;
        public LogDownloaderController(ILogDownloaderService logDownloaderService)
        {
            this.logDownloaderService = logDownloaderService;
        }

        [HttpPost]
        public async Task<ActionResult<List<Log>>> Log(LogPost model)
        {
            return Ok(await this.logDownloaderService.GetLog(model));
        }
    }; 
}
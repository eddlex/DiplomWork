using BackEnd.Helpers;
using BackEnd.Services.Interfaces;
using BackEnd.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeightController : ControllerBase
    {
        private readonly WeightService weightService;
        public WeightController(IWeightService weightService)
        {
            this.weightService = (WeightService)weightService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Models.Output.Weight>>> Weight()
        {
            return Ok(await this.weightService.GetWeights());
        }


        [HttpPost]
        public async Task<ActionResult<List<Models.Output.Weight>>> Weight(Models.Input.WeightPost weight)
        {
            return Ok(await this.weightService.AddWeight(weight));
        }


        [HttpDelete]
        public async Task<ActionResult<bool>> DelWeight(int id)
        {
            return Ok(await this.weightService.DelWeight(id));
        }

    }; 
}
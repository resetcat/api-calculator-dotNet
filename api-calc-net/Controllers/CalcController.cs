using api_calc_net.Models;
using api_calc_net.Services;
using Microsoft.AspNetCore.Mvc;


namespace api_calc_net.Controllers
{
    [Route("api/calculator")]
    [ApiController]
    public class CalcController : ControllerBase
    {
        private readonly CalcService _calcService;
        public CalcController(CalcService calcService)
        {
            _calcService = calcService;
        }

        [HttpGet("task1")]
        public List<decimal> CalculateFromIntegers([FromBody] List<CalcInput> input)
        {
            return _calcService.CalcResults(input);
        }

        [HttpGet("task2")]
        public List<decimal> CalculateFromString([FromBody] List<string> input)
        {
            return _calcService.CalculateFromString(input);
        }

        [HttpGet("task3")]
        public List<MinMaxInt> CalculateFromArray([FromBody] List<List<int>> input)
        {
            return _calcService.getMinMaxIntList(input);
        }

    }
}

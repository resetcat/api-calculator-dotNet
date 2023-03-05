using api_calc_net.Models;
using api_calc_net.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_calc_net.Controllers
{
    [Route("api/countries")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly CountryService _countryService;

        public CountryController(CountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public async Task<Countries> Get()
        {
            return await _countryService.GetContriesAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeatherAPIChallenge.Domain;
using WeatherAPIChallenge.Interfaces;

namespace WeatherAPIChallenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TemperatureController : ControllerBase
    {

        private readonly ITemperatureService _temperatureService;
        private readonly ILogger<TemperatureController> _logger;

        public TemperatureController(ILogger<TemperatureController> logger, ITemperatureService temperatureService)
        {
            _logger = logger;
            _temperatureService = temperatureService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeatherResponse>>> Get([FromQuery] string cities)
        {
            if (cities == null)
                return BadRequest("cities should not be null, Pleas add ?cities=<cityName>");
            var result = await _temperatureService.ProcesRequests(cities.Split(",").ToList());

            return Ok(result);
        }
    }
}

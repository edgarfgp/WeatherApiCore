using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeatherApiCore.IServices;
using WeatherApiCore.Model;

namespace WeatherApiCore.Controllers
{
    [Route("api/[controller]")]
    public class WeatherController : Controller
    {
        private IWeatherService weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            this.weatherService = weatherService;
        }
        [HttpGet("cities")]
        public IActionResult GetCities()
        {
            var forecast = weatherService.GetCities();

            if (forecast == null)
            {
                return NotFound();
            }
            return Ok(forecast);

        }
        [HttpGet("cities/{name}")]
        public WeatherObject GetCitiesByName(Guid id)
        {
            return this.weatherService.GetCitiesByName(id);
        }

        [HttpPost("cities")]
        public void AddForecast(WeatherObject weather)
        {
            weatherService.AddForecast(weather);
        }
    }
}
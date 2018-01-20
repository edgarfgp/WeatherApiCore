using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherApiCore.IServices;
using WeatherApiCore.Model;

namespace WeatherApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    public class WeatherController : Controller
    {
        private IWeatherService weatherService;
        public WeatherController(IWeatherService weatherService)
        {
            this.weatherService = weatherService;
        }
        [HttpGet("forecast")]
        public IEnumerable<WeatherObject> GetCityWeather()
        {
            return this.weatherService.GetCities();

        }
        [HttpGet("forecast/{name}")]
        public WeatherObject GetFilmsByName(string name)
        {
            return this.weatherService.GetCitiesByName(name);
        }
    }
}
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
        private readonly ILoggerFactory loggerFactory;

        private readonly IWeatherService weatherService;

        public WeatherController(IWeatherService weatherService, ILoggerFactory loggerFactory)
        {
            this.loggerFactory = loggerFactory;
            this.weatherService = weatherService;
        }
        [HttpGet("forecast")]
        public IEnumerable<WeatherObject> GetCityWeather()
        {
            loggerFactory.CreateLogger<WeatherController>();
            return this.weatherService.GetCities();

        }
        [HttpGet("forecast/{name}")]
        public WeatherObject GetCitiesByName(string name)
        {
            return this.weatherService.GetCitiesByName(name);
        }

        [HttpGet("forecast/{idiom}")]
        public WeatherObject GetCitiesByIdiom(string idiom)
        {
            return this.weatherService.GetCitiesByIdiom(idiom);
        }
        [HttpPost("forescast")]
        public void AddForecast(WeatherObject weather)
        {
           weatherService.AddForecast(weather);
        }
    }
}
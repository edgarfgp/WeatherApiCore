using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeatherApiCore.IServices;
using WeatherApiCore.Models;

namespace WeatherApiCore.Controllers
{
    [Route("api/weather")]
    public class WeatherController : Controller
    {
        private IWeatherService weatherService;
        private ILoggerFactory loggerFactory;
        private ILogger logger;

        public WeatherController(IWeatherService weatherService, ILoggerFactory loggerFactory)
        {
            this.weatherService = weatherService;
            this.loggerFactory = loggerFactory;
            logger = this.loggerFactory.CreateLogger<WeatherController>();
        }
        [HttpGet("cities")]
        public IActionResult GetCities()
        {
            logger.LogInformation(">>>Start GetVities<<<<< ");
            var forecastList = weatherService.GetCities();

            var forecast = Mapper.Map<IEnumerable<WeatherDto>>(forecastList);

            if (forecast == null)
            {
                return NotFound();
            }

            logger.LogInformation(">>>Ends GetVities<<<<< ");

            return Ok(forecast);


        }
        [HttpGet("cities/{id}")]
        public IActionResult GetCitiesByName(Guid id)
        {
            var cityForecast = weatherService.GetCityById(id);

            var city = Mapper.Map<WeatherDto>(cityForecast);

            if (city == null)
            {
                return NotFound($"This City Id does not exist");
            }
            return Ok(city);
        }

        //[HttpPost("cities")]
        //public void AddCity(Weather weather)
        //{
        //    weatherService.AddCity(weather);
        //}
    }
}
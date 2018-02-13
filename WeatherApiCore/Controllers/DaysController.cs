using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApiCore.IServices;
using WeatherApiCore.Models;
using WeatherApiCore.Extensions;
using WeatherApiCore.Models.OutputDto;
using WeatherApiCore.Models.InputDto;
using WeatherApiCore.Entities;

namespace WeatherApiCore.Controllers
{
    [Route("api/cities/{cityId}/days")]
    public class DaysController : Controller
    {
        private IWeatherService weatherService;
        private ILoggerFactory loggerFactory;
        private ILogger<DaysController> logger;

        public DaysController(IWeatherService weatherService, ILoggerFactory loggerFactory)
        {
            this.weatherService = weatherService;
            this.loggerFactory = loggerFactory;
            logger = this.loggerFactory.CreateLogger<DaysController>();
        }

        [HttpGet()]
        public IActionResult GetDaysForCity(Guid cityId)
        {

            logger.LogInformation(">>>>>>>Start GetDaysForCity");

            var week = weatherService.GetDaysForCity(cityId);

            if (week.Count() == 0)
            {
                return NotFound();
            }

            var days = Mapper.Map<List<DayDto>>(week);

            logger.LogInformation("<<<<Ends GetDaysForCity");

            return Ok(days);
        }

        [HttpGet("{id}", Name = "GetDayForCity")]
        public IActionResult GetDayForCity(Guid cityId, Guid id)
        {
            var day = weatherService.GetDayForCity(cityId, id);

            if (day == null)
            {
                return NotFound();
            }
            var d = Mapper.Map<DayDto>(day);

            return Ok(d);



        }

        [HttpPost()]
        public IActionResult CreateDayForWeather(Guid cityId, [FromBody] DayInputDto day)
        {
            if (day == null)
            {
                return BadRequest();

            }

            if (!weatherService.CityExists(cityId))
            {
                return NotFound();
            }

            var dayEntity = Mapper.Map<Day>(day);

            weatherService.AddDay(cityId, dayEntity);

            if (!weatherService.Save())
            {
                throw new Exception($"Creating a city Id {cityId} failed on save");
            }

            var dayToReturn = Mapper.Map<DayDto>(dayEntity);

            return CreatedAtRoute("GetDayForCity", new { cityId, id = dayToReturn.Id }, dayToReturn);
        }


    }
}

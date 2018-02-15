using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using WeatherApiCore.Entities;
using WeatherApiCore.IServices;
using WeatherApiCore.Models.CreateDto;
using WeatherApiCore.Models.Dto;

namespace WeatherApiCore.Controllers
{
    [Produces("application/json")]
    [Route("api/cities")]
    public class CitiesController : Controller
    {
        private IWeatherService weatherService;
        private ILoggerFactory loggerFactory;
        private ILogger logger;

        public CitiesController(IWeatherService weatherService, ILoggerFactory loggerFactory)
        {
            this.weatherService = weatherService;
            this.loggerFactory = loggerFactory;
            logger = this.loggerFactory.CreateLogger<CitiesController>();
        }


        [HttpGet()]
        public IActionResult GetCities()
        {
            logger.LogInformation(">>>Start GetVities<<<<< ");
            var citytList = weatherService.GetCities();

            var forecast = Mapper.Map<IEnumerable<CityDto>>(citytList);

            logger.LogInformation(">>>Ends GetVities<<<<< ");

            return Ok(forecast);

        }


        [HttpGet("{id}", Name = "GetCity")]
        public IActionResult GetCity(Guid id)
        {
            var cityForecast = weatherService.GetCity(id);

            var city = Mapper.Map<CityDto>(cityForecast);

            if (city == null)
            {
                return NotFound();
            }
            return Ok(city);
        }

        [HttpPost()]
        public IActionResult CreateCity([FromBody] CityForCreateDto city)
        {

            if (city == null)
            {
                return BadRequest();
            }

            var cityEntity = Mapper.Map<City>(city);

            weatherService.AddCity(cityEntity);

            if (!weatherService.Save())
            {
                //First Option is Thrown an Exception in order that the Middleware process it
                throw new Exception("Creating a weather failed on save");

                //Second Option is returning a StatusCode
                //return StatusCode(500, "A problem happedned with Handling your request.");

            }
            var cityToReturn = Mapper.Map<CityDto>(cityEntity);

            return CreatedAtRoute("GetCity", new { id = cityToReturn.Id }, cityToReturn);



        }

        [HttpPost("{id}")]
        public IActionResult BlockCityCreation(Guid id)
        {

            if (weatherService.CityExists(id))
            {
                return new StatusCodeResult(StatusCodes.Status409Conflict);
            }


            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCity(Guid id)
        {
            var cityFromService = weatherService.GetCity(id);

            if (cityFromService == null)
            {
                return NotFound();

            }

            weatherService.DeleteCity(cityFromService);

            if (!weatherService.Save())
            {
                throw new Exception($"Deleting city {id} failed on save");
            }

            return NoContent();


        }



    }
}
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
using WeatherApiCore.Models.Dto;
using WeatherApiCore.Models.CreateDto;
using WeatherApiCore.Entities;
using WeatherApiCore.Models.UpdateDto;
using Microsoft.AspNetCore.JsonPatch;
using WeatherApiCore.Helpers;

namespace WeatherApiCore.Controllers
{
    [Produces("application/json")]

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
        public IActionResult CreateDayForDay(Guid cityId, [FromBody] DayForCreateDto day)
        {
            if (day == null)
            {
                return BadRequest();

            }

            if (day.Description == day.Name)
            {
                ModelState.AddModelError(nameof(DayForCreateDto), "The provided description should be different from the title.");

            }

            if (!ModelState.IsValid)
            {

                return new UnprocessableEntityObjectResult(ModelState);
            }

            if (!weatherService.CityExists(cityId))
            {
                return NotFound();
            }

            var dayEntity = Mapper.Map<Day>(day);

            weatherService.AddDayForCity(cityId, dayEntity);

            if (!weatherService.Save())
            {
                throw new Exception($"Creating a city Id {cityId} failed on save");
            }

            var dayToReturn = Mapper.Map<DayDto>(dayEntity);

            return CreatedAtRoute("GetDayForCity", new { cityId, id = dayToReturn.Id }, dayToReturn);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDayForCity(Guid cityId, Guid id)
        {
            if (!weatherService.CityExists(cityId))
            {
                return NotFound();
            }

            var dayForCityFromService = weatherService.GetDayForCity(cityId, id);

            if (dayForCityFromService == null)
            {
                return NotFound();
            }

            weatherService.DeleteDay(dayForCityFromService);

            if (!weatherService.Save())
            {
                throw new Exception($"Delete day Id {id} for city id {cityId} failed on save");
            }

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDayForCity(Guid cityId, Guid id,
            [FromBody] DayForUpdateDto day)
        {

            if (day == null)
            {
                return BadRequest();
            }


            if (!weatherService.CityExists(cityId))
            {
                return NotFound();
            }

            var dayForCityFromService = weatherService.GetDayForCity(cityId, id);

            if (dayForCityFromService == null)
            {
                var dayToAdd = Mapper.Map<Day>(day);
                dayToAdd.Id = id;

                weatherService.AddDayForCity(cityId, dayToAdd);
                //return NotFound();

                if (!weatherService.Save())
                {
                    throw new Exception($"Upserting day {id}  for city Id {cityId} failed on save");
                }

                var dayToReturn = Mapper.Map<DayDto>(dayToAdd);

                return CreatedAtRoute("GetDayForCity", new { cityId, id = dayToReturn.Id }, dayToReturn);
            }

            Mapper.Map(day, dayForCityFromService);

            weatherService.UpdateDayForCity(dayForCityFromService);

            if (!weatherService.Save())
            {
                throw new Exception($"Updating day {id} for City {cityId} failed on save");
            }

            return NoContent();


        }

        /// <summary>
        /// This Method is used to make Partial Updates using application/json-patch standar
        /// </summary>
        /// <param name="cityId">The Id of the city</param>
        /// <param name="id">The Id of the day</param>
        /// <param name="patchDoc">Type JsonPatch Document</param>
        /// <returns></returns>
        /// <remarks>this is for partial updates</remarks>
        [HttpPatch("{id}")]
        public IActionResult PartiallyUpdateDayForCity(Guid cityId, Guid id,
            [FromBody] JsonPatchDocument<DayForUpdateDto> patchDoc)
        {

            if (patchDoc == null)
            {
                return BadRequest();
            }

            if (!weatherService.CityExists(cityId))
            {
                return NotFound();
            }

            var dayForCityFromService = weatherService.GetDayForCity(cityId, id);

            if (dayForCityFromService == null)
            {
                //return NotFound();
                var dayDto = new DayForUpdateDto();
                patchDoc.ApplyTo(dayDto);

                var dayToAdd = Mapper.Map<Day>(dayDto);

                dayToAdd.Id = id;

                weatherService.AddDayForCity(cityId, dayToAdd);

                if (!weatherService.Save())
                {

                    throw new Exception($"Upserting  day id {id} for citi Id {cityId} failed on save.");


                }

                var dayToReturn = Mapper.Map<DayDto>(dayToAdd);

                return CreatedAtRoute("GetDayForCity", new { cityId = cityId }, id = dayToReturn.Id);



            }

            var dayToPatch = Mapper.Map<DayForUpdateDto>(dayForCityFromService);

            patchDoc.ApplyTo(dayToPatch);

            //TODO validation mas be implemented

            Mapper.Map(dayToPatch, dayForCityFromService);

            weatherService.UpdateDayForCity(dayForCityFromService);

            if (!weatherService.Save())
            {
                throw new Exception($"Patching day Id {id} for city Id {cityId} failed on save");
            }

            return NoContent();



        }



    }
}

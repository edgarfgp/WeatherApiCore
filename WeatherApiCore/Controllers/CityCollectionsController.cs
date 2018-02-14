using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using WeatherApiCore.Entities;
using WeatherApiCore.Helpers;
using WeatherApiCore.IServices;
using WeatherApiCore.Models.InputDto;
using WeatherApiCore.Models.OutputDto;

namespace WeatherApiCore.Controllers
{
    [Produces("application/json")]
    [Route("api/CityCollections")]
    public class CityCollectionsController : Controller
    {

        private IWeatherService weatherService;


        public CityCollectionsController(IWeatherService weatherService)
        {
            this.weatherService = weatherService;
        }
        [HttpPost()]
        public IActionResult CreateCityCollectio([FromBody] IEnumerable<CityInputDto> cityCollection)
        {

            if (cityCollection == null)
            {
                return BadRequest();
            }

            var citiesEntities = Mapper.Map<IEnumerable<City>>(cityCollection);

            foreach (var city in citiesEntities)
            {
                weatherService.AddCity(city);
            }

            if (!weatherService.Save())
            {
                throw new Exception($"Creating a city Collection  failed on save");
            }

            var cityCollectionReturn = Mapper.Map<IEnumerable<CityDto>>(citiesEntities);

            var idsAsString = string.Join(",", cityCollectionReturn.Select(c => c.Id));


            return CreatedAtRoute("GetCityCollection", new { ids = idsAsString }, cityCollectionReturn);
            //return Ok();

        }

        [HttpGet("({ids})", Name ="GetCityCollection")]
        public IActionResult GetCityCollection([ModelBinder(BinderType =typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            if (ids == null)
            {
                return BadRequest();
            }

            var citiesEntities = weatherService.GetCities(ids);

            if (ids.Count() != citiesEntities.Count())
            {
                return NotFound();
            }

            var citiesToReturn = Mapper.Map<IEnumerable<DayDto>>(citiesEntities);

            return Ok(citiesToReturn);

        }

    }
}
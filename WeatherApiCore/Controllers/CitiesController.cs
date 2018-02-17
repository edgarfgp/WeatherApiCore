using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using WeatherApiCore.Entities;
using WeatherApiCore.Helpers;
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
        private ILogger<CitiesController> logger;
        private IUrlHelper urlHelper;
        private IPropertyMappingService propertyMappingService;


        public CitiesController(IWeatherService weatherService, ILogger<CitiesController> logger, IUrlHelper urlHelper,
            IPropertyMappingService propertyMappingService)
        {
            this.weatherService = weatherService;
            this.logger = logger;
            this.urlHelper = urlHelper;
            this.propertyMappingService = propertyMappingService;
        }


        [HttpGet(Name = "GetCities")]
        public IActionResult GetCities(CitiesResourcesParameters citiesResourcesParameters)
        {
            logger.LogInformation(">>>Start GetVities<<<<< ");

            if (!propertyMappingService.ValidMappingExistsFor<CityDto, City>(citiesResourcesParameters.OrderBy))
            {
                return BadRequest();
            }
            var cityFromService = weatherService.GetCities(citiesResourcesParameters);

            var previousPageLink = cityFromService.HasPrevious ?
                CreateCityResourceUri(citiesResourcesParameters,
                ResourceUriType.PreviousPage) : null;


            var nextPageLink = cityFromService.HasNext ?
                CreateCityResourceUri(citiesResourcesParameters,
                ResourceUriType.NextPage) : null;

            var paginationMetadata = new
            {
                totalCount = cityFromService.TotalCount,
                pageSize = cityFromService.PageSize,
                currentPage = cityFromService.CurrentPage,
                totalPages = cityFromService.TotalPages,
                previousPageLink,
                nextPageLink
            };

            Response.Headers.Add("X-Pagination", Newtonsoft.Json.JsonConvert.SerializeObject(paginationMetadata));


            var cities = Mapper.Map<IEnumerable<CityDto>>(cityFromService);

            logger.LogInformation(">>>Ends GetVities<<<<< ");

            return Ok(cities);

        }


        private string CreateCityResourceUri(CitiesResourcesParameters citiesResourcesParameters, ResourceUriType type)
        {
            switch (type)
            {
                case ResourceUriType.PreviousPage:
                    return urlHelper.Link("GetCities",
                      new
                      {
                          orderBy = citiesResourcesParameters.OrderBy,
                          searchQuery = citiesResourcesParameters.SearchQuery,
                          cityName = citiesResourcesParameters.CityName,
                          pageNumber = citiesResourcesParameters.PageNumber - 1,
                          pageSize = citiesResourcesParameters.PageSize
                      });
                case ResourceUriType.NextPage:
                    return urlHelper.Link("GetCities",
                      new
                      {
                          orderBy = citiesResourcesParameters.OrderBy,
                          searchQuery = citiesResourcesParameters.SearchQuery,
                          cityName = citiesResourcesParameters.CityName,
                          pageNumber = citiesResourcesParameters.PageNumber + 1,
                          pageSize = citiesResourcesParameters.PageSize
                      });

                default:
                    return urlHelper.Link("GetCities",
                    new
                    {
                        orderBy = citiesResourcesParameters.OrderBy,
                        searchQuery = citiesResourcesParameters.SearchQuery,
                        cityName = citiesResourcesParameters.CityName,
                        pageNumber = citiesResourcesParameters.PageNumber,
                        pageSize = citiesResourcesParameters.PageSize
                    });
            }

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
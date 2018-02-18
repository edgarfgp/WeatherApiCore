using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using WeatherApiCore.Entities;
using WeatherApiCore.Extensions;
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
        private ITypeHelperService typeHelperService;

        public CitiesController(IWeatherService weatherService, ILogger<CitiesController> logger, IUrlHelper urlHelper,
            IPropertyMappingService propertyMappingService, ITypeHelperService typeHelperService)
        {
            this.weatherService = weatherService;
            this.logger = logger;
            this.urlHelper = urlHelper;
            this.propertyMappingService = propertyMappingService;
            this.typeHelperService = typeHelperService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="citiesResourcesParameters"></param>
        /// <param name="mediaType"></param>
        /// <returns></returns>
        [HttpGet(Name = "GetCities")]
        public IActionResult GetCities(CitiesResourcesParameters citiesResourcesParameters,
            [FromHeader(Name = "Accept")]string mediaType)
        {

            if (!propertyMappingService.ValidMappingExistsFor<CityDto, City>(citiesResourcesParameters.OrderBy))
            {
                return BadRequest();
            }

            if (!typeHelperService.TypeHasProperties<CityDto>(citiesResourcesParameters.Fields))
            {
                return BadRequest();

            }
            var cityFromService = weatherService.GetCities(citiesResourcesParameters);


            var cities = Mapper.Map<IEnumerable<CityDto>>(cityFromService);
            
            if (mediaType == "application/vnd.marvin.hateoas+json")
            {

                var paginationMetadata = new
                {
                    totalCount = cityFromService.TotalCount,
                    pageSize = cityFromService.PageSize,
                    currentPage = cityFromService.CurrentPage,
                    totalPages = cityFromService.TotalPages,

                };

                Response.Headers.Add("X-Pagination", Newtonsoft.Json.JsonConvert.SerializeObject(paginationMetadata));


                var links = CreateLinksForCities(citiesResourcesParameters, cityFromService.HasNext, cityFromService.HasPrevious);

                var shapedCities = cities.ShapeData(citiesResourcesParameters.Fields);

                var shapedCitiesWithLinks = shapedCities.Select(city =>
                {
                    var cityAsADictionary = city as IDictionary<string, object>;
                    var cityLinks = CreateLinksForCity((Guid)cityAsADictionary["Id"], citiesResourcesParameters.Fields);

                    cityAsADictionary.Add("links", cityLinks);

                    return cityAsADictionary;
                });

                var linkedCollectionResource = new
                {
                    value = shapedCitiesWithLinks,
                    links
                };

                

                return Ok(linkedCollectionResource);
            }
            else
            {
                var previousPageLink = cityFromService.HasPrevious ?
                    CreateCityResourceUri(citiesResourcesParameters,
                    ResourceUriType.PreviousPage) : null;

                var nextPageLink = cityFromService.HasNext ?
                    CreateCityResourceUri(citiesResourcesParameters,
                    ResourceUriType.NextPage) : null;

                var paginationMetadata = new
                {
                    previousPageLink,
                    nextPageLink,
                    totalCount = cityFromService.TotalCount,
                    pageSize = cityFromService.PageSize,
                    currentPage = cityFromService.CurrentPage,
                    totalPages = cityFromService.TotalPages
                };

                Response.Headers.Add("X-Pagination",
                    Newtonsoft.Json.JsonConvert.SerializeObject(paginationMetadata));

                return Ok(cities.ShapeData(citiesResourcesParameters.Fields));
            }
        }


        private string CreateCityResourceUri(CitiesResourcesParameters citiesResourcesParameters, ResourceUriType type)
        {
            switch (type)
            {
                case ResourceUriType.PreviousPage:
                    return urlHelper.Link("GetCities",
                      new
                      {
                          fields = citiesResourcesParameters.Fields,
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
                          fields = citiesResourcesParameters.Fields,
                          orderBy = citiesResourcesParameters.OrderBy,
                          searchQuery = citiesResourcesParameters.SearchQuery,
                          cityName = citiesResourcesParameters.CityName,
                          pageNumber = citiesResourcesParameters.PageNumber + 1,
                          pageSize = citiesResourcesParameters.PageSize
                      });
                case ResourceUriType.Current:
                default:
                    return urlHelper.Link("GetCities",
                    new
                    {
                        fields = citiesResourcesParameters.Fields,
                        orderBy = citiesResourcesParameters.OrderBy,
                        searchQuery = citiesResourcesParameters.SearchQuery,
                        cityName = citiesResourcesParameters.CityName,
                        pageNumber = citiesResourcesParameters.PageNumber,
                        pageSize = citiesResourcesParameters.PageSize
                    });
            }

        }


        [HttpGet("{id}", Name = "GetCity")]
        public IActionResult GetCity(Guid id, [FromQuery] string fields)
        {
            if (!typeHelperService.TypeHasProperties<CityDto>(fields))
            {
                return BadRequest();
            }
            var cityFromService = weatherService.GetCity(id);



            if (cityFromService == null)
            {
                return NotFound();
            }

            var city = Mapper.Map<CityDto>(cityFromService);

            var links = CreateLinksForCity(id, fields);

            var linkedDictionaryToReturn = city.ShapeData(fields) as IDictionary<string, object>;

            linkedDictionaryToReturn.Add("links", links);

            return Ok(linkedDictionaryToReturn);
        }

        [HttpPost(Name = "CreateCity")]
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

            var links = CreateLinksForCity(cityToReturn.Id, null);

            var linkedResourceToReturn = cityToReturn.ShapeData(null) as IDictionary<string, object>;

            linkedResourceToReturn.Add("links", links);

            return CreatedAtRoute("GetCity", new { id = linkedResourceToReturn["Id"] }, linkedResourceToReturn);



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

        [HttpDelete("{id}", Name = "DeleteCity")]
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


        private IEnumerable<LinkDto> CreateLinksForCity(Guid id, string fields)
        {

            var links = new List<LinkDto>();

            if (string.IsNullOrWhiteSpace(fields))
            {

                links.Add(
                    new LinkDto(urlHelper.Link("GetCity", new { id }),
                    "self",
                    "GET"));

            }
            else
            {

                links.Add(
                    new LinkDto(urlHelper.Link("GetCity", new { id, fields }),
                    "self",
                    "GET"));

            }


            links.Add(
                new LinkDto(urlHelper.Link("DeleteCity", new { id }),
                "delete_city",
                "DELETE"));

            links.Add(
               new LinkDto(urlHelper.Link("CreateDayForCity", new { cityId = id }),
               "create_day_for_city",
               "POST"));

            links.Add(
               new LinkDto(urlHelper.Link("GetDaysForCity", new { cityId = id }),
               "days",
               "GET"));


            return links;

        }

        private IEnumerable<LinkDto> CreateLinksForCities(
           CitiesResourcesParameters citiesResourceParameters,
           bool hasNext, bool hasPrevious)
        {
            var links = new List<LinkDto>();

            // self 
            links.Add(
               new LinkDto(CreateCityResourceUri(citiesResourceParameters,
               ResourceUriType.Current)
               , "self", "GET"));

            if (hasNext)
            {
                links.Add(
                  new LinkDto(CreateCityResourceUri(citiesResourceParameters,
                  ResourceUriType.NextPage),
                  "nextPage", "GET"));
            }

            if (hasPrevious)
            {
                links.Add(
                    new LinkDto(CreateCityResourceUri(citiesResourceParameters,
                    ResourceUriType.PreviousPage),
                    "previousPage", "GET"));
            }

            return links;
        }



    }
}
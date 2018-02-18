using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApiCore.Models.Dto;

namespace WeatherApiCore.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    public class RootController : Controller
    {
        private IUrlHelper urlHelper;

        public RootController(IUrlHelper urlHelper)
        {
            this.urlHelper = urlHelper;

        }

        [HttpGet(Name = "GetRoot")]
        public IActionResult GetRoot([FromHeader] string mediaType)
        {
            if (mediaType == "application/vnd.marvin.hateoas+json")
            {
                var links = new List<LinkDto>();

                links.Add(new LinkDto(urlHelper.Link("GetRoot", new { }), "self", "GET"));

                links.Add(new LinkDto(urlHelper.Link("GetCities", new { }), "cities", "GET"));

                links.Add(new LinkDto(urlHelper.Link("CreateCity", new { }), "create_city", "POST"));

                return Ok(links);

            }

            return NoContent();
        }
    }
}

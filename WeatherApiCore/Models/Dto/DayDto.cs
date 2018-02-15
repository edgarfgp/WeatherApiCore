using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApiCore.Models.Dto
{
    public class DayDto
    {

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string TempMaxMin { get; set; }

        public Guid CityId { get; set; }



    }
}

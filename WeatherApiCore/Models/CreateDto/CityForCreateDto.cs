using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApiCore.Models.CreateDto
{
    public class CityForCreateDto
    {

        public string Country { get; set; }

        public string CityName { get; set; }

        public ICollection<DayForCreateDto> Days { get; set; }
        = new List<DayForCreateDto>();
    }
}

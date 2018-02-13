using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApiCore.Models.InputDto
{
    public class CityInputDto
    {

        public string Country { get; set; }

        public string CityName { get; set; }

        public ICollection<DayInputDto> Days { get; set; }
        = new List<DayInputDto>();
    }
}

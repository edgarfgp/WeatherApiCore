using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApiCore.Entities;

namespace WeatherApiCore.Models.OutputDto
{
    public class CityDto
    {

        public Guid Id { get; set; }

        public string Location { get; set; }

        public ICollection<DayDto> WeekDays { get; set; }
            = new List<DayDto>();

    }
}

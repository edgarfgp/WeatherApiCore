using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApiCore.Models.UpdateDto
{
    public class DayForUpdateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Temp { get; set; }
        public long Humidity { get; set; }
        public long TempMin { get; set; }
        public long TempMax { get; set; }
    }
}

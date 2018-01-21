using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApiCore.Model
{
    public class WeatherObject
    {
        public string Country { get; set; }
        public string City { get; set; }
        public DateTime LocalTime { get; set; }
        public string Idiom { get; set; }
        public long TemperatureMax { get; set; }
        public long TemperatureMin { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApiCore.Model
{
    public class WeatherObject
    {
        public string City { get; set; }
        public string  Country { get; set; }

        public long TemperatureMax { get; set; }
        public long TemperatureMin { get; set; }


    }
}

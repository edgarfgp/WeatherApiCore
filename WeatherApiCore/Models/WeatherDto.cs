using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApiCore.Models
{
    public class WeatherDto
    {
        public Guid Id { get; set; }

        public string Location { get; set; }

        public DateTime ForecastDate { get; set; }

        public double Temperature { get; set; }

        public long TempMin { get; set; }

        public long TempMax { get; set; }

        public string Description { get; set; }

    }
}

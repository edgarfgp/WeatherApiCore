using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WeatherApiCore.Models.Base;

namespace WeatherApiCore.Models.CreateDto
{
    public class DayForCreateDto : DayForManipulationDto
    {

        public double Temp { get; set; }

        public long Humidity { get; set; }

        public long TempMin { get; set; }

        public long TempMax { get; set; }

    }
}

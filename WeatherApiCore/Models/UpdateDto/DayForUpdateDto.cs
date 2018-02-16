using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WeatherApiCore.Models.Base;

namespace WeatherApiCore.Models.UpdateDto
{
    public class DayForUpdateDto : DayForManipulationDto
    {
        public override string Name { get => base.Name; set => base.Name = value; }

        [Required(ErrorMessage = "You Should fill out a description")]
        public override string Description { get => base.Description; set => base.Description = value; }
        public double Temp { get; set; }

        public long Humidity { get; set; }

        public long TempMin { get; set; }

        public long TempMax { get; set; }
    }
}

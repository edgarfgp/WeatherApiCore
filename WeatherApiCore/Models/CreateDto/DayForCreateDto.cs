using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApiCore.Models.CreateDto
{
    public class DayForCreateDto
    {
        [Required(ErrorMessage = "You should fill out a title.")]
        [MaxLength(100, ErrorMessage = "The title shouldn't have more than 100 characters.")]
        public string Name { get; set; }


        [MaxLength(100, ErrorMessage = "The description shouldn't have more than 500 characters.")]
        public string Description { get; set; }

        public double Temp { get; set; }

        public long Humidity { get; set; }

        public long TempMin { get; set; }

        public long TempMax { get; set; }

    }
}

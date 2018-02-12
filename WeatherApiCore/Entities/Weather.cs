using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApiCore.Entities
{
    public class Weather
    {

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Country { get; set; }

        [Required]
        [MaxLength(20)]
        public string CityName { get; set; }

        [Required]
        public DateTime ForecastDate { get; set; }

        public string Icon { get; set; }
        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        [Required]
        [MaxLength(20)]
        public double Temp { get; set; }


        public long Pressure { get; set; }


        public long Humidity { get; set; }

        [Required]
        public long TempMin { get; set; }

        [Required]
        public long TempMax { get; set; }

    }






}





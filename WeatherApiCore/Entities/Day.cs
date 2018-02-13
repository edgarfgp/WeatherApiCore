using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApiCore.Entities
{
    public class Day
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        public string Icon { get; set; }

        [ForeignKey("CityId")]
        public City City { get; set; }

        public Guid CityId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        [Required]
        public double Temp { get; set; }

        [Required]
        public long Humidity { get; set; }

        [Required]
        public long TempMin { get; set; }

        [Required]
        public long TempMax { get; set; }
    }
}

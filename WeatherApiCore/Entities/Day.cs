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

        
        [MaxLength(200)]
        public string Description { get; set; }

        
        public double Temp { get; set; }

       
        public long Humidity { get; set; }

      
        public long TempMin { get; set; }

        
        public long TempMax { get; set; }
    }
}

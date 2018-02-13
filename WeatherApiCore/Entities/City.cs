using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApiCore.Entities
{
    public class City
    {

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Country { get; set; }

        [Required]
        [MaxLength(20)]
        public string CityName { get; set; }


        public ICollection<Day> Days { get; set; }
            = new List<Day>();


    }
}





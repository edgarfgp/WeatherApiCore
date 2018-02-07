using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApiCore.Model
{
    public class WeatherObject
    {
        public int Id { get; set; }
        public string Country { get; set; }

        public string CityName { get; set; }

        public string Icon { get; set; }

        public string Description { get; set; }


        public double Temp { get; set; }

        public long Pressure { get; set; }


        public long Humidity { get; set; }


        public long TempMin { get; set; }


        public long TempMax { get; set; }

    }

   


    
      
    }





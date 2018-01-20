using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApiCore.IServices;
using WeatherApiCore.Model;

namespace WeatherApiCore.Services
{
    public class WeatherService : IWeatherService
    {
        private IEnumerable<WeatherObject> weatherObjectList; 
        public WeatherService()
        {
            weatherObjectList = new List<WeatherObject>(){
                new WeatherObject { Country = "Spain", City="Madrid", TemperatureMin = 08, TemperatureMax= 10 },
                 new WeatherObject { Country = "UK", City="London", TemperatureMin = 05, TemperatureMax= 09 },
                 new WeatherObject { Country = "Italy", City="Rome", TemperatureMin = 14, TemperatureMax= 18 },

            };
        }
        public IEnumerable<WeatherObject> GetCities()
        {
            return weatherObjectList;
        }

        public WeatherObject GetCitiesByName(string name)
        {
            return weatherObjectList.Where(x => x.City.ToLower().Equals(name.ToLower())).FirstOrDefault();
        }
    }
}

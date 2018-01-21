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
        private List<WeatherObject> WeatherObjectList { get; set; }


        public WeatherService()
        {
            WeatherObjectList = new List<WeatherObject>(){
                 new WeatherObject { Country = "Spain",  City= "Madrid",  Idiom = "Spanish", LocalTime = DateTime.Now,  TemperatureMin = 08, TemperatureMax= 10 },
                 new WeatherObject { Country = "UK", City="London",  Idiom = "English", LocalTime = DateTime.Now,  TemperatureMin = 05, TemperatureMax= 09 },
                 new WeatherObject { Country = "Italy", City="Rome",  Idiom = "Italian", LocalTime = DateTime.Now, TemperatureMin = 14, TemperatureMax= 18 },

            };
        }
        IEnumerable<WeatherObject> IWeatherService.GetCities()
        {
            return WeatherObjectList;
        }

        WeatherObject IWeatherService.GetCitiesByIdiom(string idiom)
        {
            return WeatherObjectList.FirstOrDefault(x => x.Idiom.ToLower().Equals(idiom.ToLower()));
        }

        public void AddForecast(WeatherObject weather)
        {
            WeatherObjectList.ToList().Add(weather);
        }

        WeatherObject IWeatherService.GetCitiesByName(string name)
        {
            return WeatherObjectList.FirstOrDefault(x => x.City.ToLower().Equals(name.ToLower()));
        }

    }
}

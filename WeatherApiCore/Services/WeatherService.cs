using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApiCore.IServices;
using WeatherApiCore.Model;

namespace WeatherApiCore.Services
{
    public class WeatherService : IWeatherService, IWeatherService2
    {
        private IEnumerable<WeatherObject> weatherObjectList1;
        private IEnumerable<WeatherObject2> weatherObjectList2;

        public WeatherService()
        {
            weatherObjectList1 = new List<WeatherObject>(){
                new WeatherObject { Country = "Spain", City="Madrid", TemperatureMin = 08, TemperatureMax= 10 },
                 new WeatherObject { Country = "UK", City="London", TemperatureMin = 05, TemperatureMax= 09 },
                 new WeatherObject { Country = "Italy", City="Rome", TemperatureMin = 14, TemperatureMax= 18 },

            };
            weatherObjectList2 = new List<WeatherObject2>(){
                 new WeatherObject2 { Country = "Ecuador", Idiom = "Diga Patroncito", LocalTime = DateTime.Now, City="Loja", TemperatureMin = 28, TemperatureMax= 35 },
                 new WeatherObject2 { Country = "Peu",  Idiom = "Pata ues home", LocalTime = DateTime.Now, City="Lima", TemperatureMin = 18, TemperatureMax= 22 },
                 new WeatherObject2 { Country = "Colombia", Idiom = "Colombian Parcero", LocalTime = DateTime.Now, City="Rome", TemperatureMin = 14, TemperatureMax= 18 },

            };
        }
        IEnumerable<WeatherObject> IWeatherService.GetCities()
        {
            return weatherObjectList1;
        }

        WeatherObject2 IWeatherService2.GetCitiesByIdiom(string idiom)
        {
            return weatherObjectList2.Where(x => x.Idiom.ToLower().Equals(idiom.ToLower())).FirstOrDefault();
        }

        WeatherObject IWeatherService.GetCitiesByName(string name)
        {
            return weatherObjectList1.Where(x => x.City.ToLower().Equals(name.ToLower())).FirstOrDefault();
        }

        IEnumerable<WeatherObject2> IWeatherService2.GetCities()
        {
            return weatherObjectList2;
        }

        WeatherObject2 IWeatherService2.GetCitiesByName(string name)
        {
            return weatherObjectList2.Where(x => x.City.ToLower().Equals(name.ToLower())).FirstOrDefault();
        }
    }
}

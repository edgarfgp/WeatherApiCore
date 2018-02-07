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
        static List<WeatherObject> WeatherObjectList = new List<WeatherObject>(){
                 new WeatherObject
                 {
                     Id = 1,
                     Country = "Spain",
                     CityName = "Madrid",
                     Description ="Clear Sky Day",
                     Humidity = 20,
                     Icon = "https://images.pexels.com/photos/133953/pexels-photo-133953.jpeg?w=940&h=650&auto=compress&cs=tinysrgb",
                     Temp = 0,
                     Pressure = 25,
                     TempMin = -2,
                     TempMax = 5
                 }
            };




        IEnumerable<WeatherObject> IWeatherService.GetCities()
        {
            return WeatherObjectList;
        }

        WeatherObject IWeatherService.AddForecast(WeatherObject weather)
        {
            if (weather != null)
            {
                WeatherObjectList.Add(weather);
                return weather;
            }
            else
            {
                return null;
            }

        }

        WeatherObject IWeatherService.GetCitiesByName(string name)
        {
            return WeatherObjectList.FirstOrDefault(x => x.CityName.ToLower().Equals(name.ToLower()));
        }

    }
}

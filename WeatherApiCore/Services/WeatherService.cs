using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApiCore.Entities;
using WeatherApiCore.IServices;

namespace WeatherApiCore.Services
{
    public class WeatherService : IWeatherService
    {
        static List<Weather> WeatherObjectList = new List<Weather>(){
                 new Weather
                 {
                     Id = Guid.NewGuid(),
                     Country = "Spain",
                     CityName = "Barcelona",
                     ForecastDate = DateTime.Now,
                     Description ="Blue Sky Day",
                     Humidity = 20,
                     Icon = "https://images.pexels.com/photos/133953/pexels-photo-133953.jpeg?w=940&h=650&auto=compress&cs=tinysrgb",
                     Temp = 0,
                     Pressure = 25,
                     TempMin = -2,
                     TempMax = 5
                 }
            };




        IEnumerable<Weather> IWeatherService.GetCities()
        {
            return WeatherObjectList;
        }

        void IWeatherService.AddCity(Weather weather)
        {
            if (weather != null)
            {
                WeatherObjectList.Add(weather);

            }


        }

        Weather IWeatherService.GetCityById(Guid id)
        {
            return WeatherObjectList.FirstOrDefault(city => city.Id == id);
        }

    }
}

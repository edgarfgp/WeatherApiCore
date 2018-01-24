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
                 new WeatherObject
                 {
                      Coord =new Coord {Lat=3.7, Lon=40.42 },
                      Weather = new Weather[]
                      {
                          new Weather
                          {
                            Description ="clear sky",
                            Icon = "01n",
                            Id=800,
                            Main = "Clear"
                          },
                           new Weather
                          {
                            Description ="clear sky",
                            Icon = "01n",
                            Id=800,
                            Main = "Clear"
                          }

                      },
                      Base = "stations",
                      Main = new Main
                      {
                          Temp = 5,
                          Pressure = 1029,
                          Humidity = 93,
                          TempMax = 5,
                          TempMin = 3
                      },
                      Visibility = 100000,
                      Wind = new Wind
                      {
                          Speed = 1.5,
                          Deg = 350

                      },
                      Clouds = new Clouds
                      {
                          All= 0
                      },
                      Dt = 151616658400,
                      Sys = new Sys
                      {
                          Type = 1,
                          Id = 5488,
                          Message = 0.212124,
                          Country ="Spain",
                          Sunrise = 15151548,
                          Sunset = 254789965,

                      },
                      
                      Name = "Madrid",
                      Cod = 20
                 },
                 new WeatherObject
                 {
                      Coord =new Coord {Lat=3.7, Lon=40.42 },
                      Weather = new Weather[]
                      {
                          new Weather
                          {
                            Description ="clear sky",
                            Icon = "01n",
                            Id=800,
                            Main = "Clear"
                          },
                           new Weather
                          {
                            Description ="clear sky",
                            Icon = "01n",
                            Id=800,
                            Main = "Clear"
                          }

                      },
                      Base = "stations",
                      Main = new Main
                      {
                          Temp = 5,
                          Pressure = 1029,
                          Humidity = 93,
                          TempMax = 5,
                          TempMin = 3
                      },
                      Visibility = 100000,
                      Wind = new Wind
                      {
                          Speed = 1.5,
                          Deg = 350

                      },
                      Clouds = new Clouds
                      {
                          Id = 123,
                          All= 0
                      },
                      Dt = 151616658400,
                      Sys = new Sys
                      {
                          Type = 1,
                          Id = 5488,
                          Message = 0.212124,
                          Country ="UK",
                          Sunrise = 15151548,
                          Sunset = 254789965,
                      },
                      
                      Name = "London",
                      Cod = 20
                 }
            };
        }
        IEnumerable<WeatherObject> IWeatherService.GetCities()
        {
            return WeatherObjectList;
        }

        public void AddForecast(WeatherObject weather)
        {
            WeatherObjectList.ToList().Add(weather);
        }

        WeatherObject IWeatherService.GetCitiesByName(string name)
        {
            return WeatherObjectList.FirstOrDefault(x => x.Name.ToLower().Equals(name.ToLower()));
        }

    }
}

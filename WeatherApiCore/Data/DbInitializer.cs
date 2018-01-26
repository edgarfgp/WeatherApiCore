using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApiCore.Model;

namespace WeatherApiCore.Data
{
    public sealed class DbInitializer
    {
        private DBContext context;

        public DbInitializer(DBContext context)
        {
            this.context = context;
        }
        public void SeedData()
        {
            if (!context.WeatherForecast.Any())
            {
                context.WeatherForecast.Add(new WeatherObject
                {
                    Coord = new Coord { Lat = 3.7, Lon = 40.42 },
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
                        All = 0
                    },
                    Dt = 151616658400,
                    Sys = new Sys
                    {
                        Type = 1,
                        Id = 5488,
                        Message = 0.212124,
                        Country = "Spain",
                        Sunrise = 15151548,
                        Sunset = 254789965,

                    },

                    Name = "Madrid",
                    Cod = 20
                });
                context.WeatherForecast.Add(new WeatherObject
                {
                    Coord = new Coord { Lat = 3.7, Lon = 40.42 },
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
                        Id = 125,
                        All = 0
                    },
                    Dt = 151616658400,
                    Sys = new Sys
                    {
                        Type = 1,
                        Id = 5488,
                        Message = 0.212124,
                        Country = "UK",
                        Sunrise = 15151548,
                        Sunset = 254789965,
                    },

                    Name = "London",
                    Cod = 20
                });
                    
                context.SaveChanges();
            }
            
        }
    }
}


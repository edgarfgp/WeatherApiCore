using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApiCore.Data;
using WeatherApiCore.Model;

namespace WeatherApiCore.Data
{
    public static class DbInitializer
    {

        public static void Seed(DBContext context)
        {
            if (!context.WeatherForecast.Any())
            {
                context.AddRange
                (
                    new WeatherObject
                    {
                        Id =Guid.NewGuid(),
                        Country = "Spain",
                        CityName = "Madrid",
                        Description = "Clear Sky Day",
                        Humidity = 20,
                        Icon = "https://images.pexels.com/photos/133953/pexels-photo-133953.jpeg?w=940&h=650&auto=compress&cs=tinysrgb",
                        Temp = 0,
                        Pressure = 25,
                        TempMin = -2,
                        TempMax = 5
                    }
                    
                );
            }
            context.SaveChanges();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApiCore.Data;
using WeatherApiCore.Entities;
using WeatherApiCore.IServices;

namespace WeatherApiCore.Services
{
    public class WeatherEFService : IWeatherService
    {
        private WeatherDBContext context;
        public WeatherEFService(WeatherDBContext context)
        {
            this.context = context;
        }
         void IWeatherService.AddCity(Weather weather)
        {
            weather.Id = Guid.NewGuid();
            context.WeatherForecast.Add(weather);
            context.SaveChanges();


        }

         IEnumerable<Weather> IWeatherService.GetCities()
        {
            return context.WeatherForecast;
        }

        public Weather GetCityById(Guid id)
        {
            return context.WeatherForecast.ToList().FirstOrDefault(x => x.Id == id);

        }
    }
}

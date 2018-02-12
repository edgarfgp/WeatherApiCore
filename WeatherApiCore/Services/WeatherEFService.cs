using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApiCore.Data;
using WeatherApiCore.IServices;
using WeatherApiCore.Model;

namespace WeatherApiCore.Services
{
    public class WeatherEFService : IWeatherService
    {
        private DBContext context;
        public WeatherEFService(DBContext context)
        {
            this.context = context;
        }
        public void AddForecast(WeatherObject weather)
        {

            context.WeatherForecast.Add(weather);
            context.SaveChanges();


        }

        public IEnumerable<WeatherObject> GetCities()
        {
            return context.WeatherForecast.ToList();
        }

        public WeatherObject GetCitiesByName(Guid id)
        {
            return context.WeatherForecast.ToList().FirstOrDefault(x => x.Id == id);

        }
    }
}

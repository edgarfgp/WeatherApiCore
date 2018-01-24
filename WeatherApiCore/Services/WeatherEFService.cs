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
            context.Add(weather);
        }

        public IEnumerable<WeatherObject> GetCities()
        {
            return context.WeatherForecast.ToList();
        }

        public WeatherObject GetCitiesByName(string name)
        {
            return context.WeatherForecast.ToList().FirstOrDefault(x => x.Name.Equals(name));
        }
    }
}

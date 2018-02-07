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
        private DBContext _context;
        public WeatherEFService(DBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public WeatherObject AddForecast(WeatherObject weather)
        {

            _context.Add(weather);
            return weather;



        }

        public IEnumerable<WeatherObject> GetCities()
        {
            return _context.WeatherForecast.ToList();
        }

        public WeatherObject GetCitiesByName(string name)
        {
            return _context.WeatherForecast.ToList().FirstOrDefault(x => x.CityName.Equals(name));
        }
    }
}

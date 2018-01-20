using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApiCore.Model;

namespace WeatherApiCore.IServices
{
    public interface IWeatherService
    {
        IEnumerable<WeatherObject> GetCities();
        WeatherObject GetCitiesByName(string name);
    }
}

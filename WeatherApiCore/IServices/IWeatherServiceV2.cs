using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApiCore.Model;

namespace WeatherApiCore.IServices
{
    public interface IWeatherService2
    {
        IEnumerable<WeatherObject2> GetCities();
        WeatherObject2 GetCitiesByName(string name);
        WeatherObject2 GetCitiesByIdiom(string idiom);


    }
}

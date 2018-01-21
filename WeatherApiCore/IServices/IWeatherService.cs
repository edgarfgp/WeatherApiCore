using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using WeatherApiCore.Model;

namespace WeatherApiCore.IServices
{
    public interface IWeatherService
    {
        IEnumerable<WeatherObject> GetCities();
        WeatherObject GetCitiesByName(string name);

        WeatherObject GetCitiesByIdiom(string idiom);

        void AddForecast(WeatherObject weather);


    }
}

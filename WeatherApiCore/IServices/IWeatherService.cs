using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using WeatherApiCore.Entities;
using WeatherApiCore.Models;

namespace WeatherApiCore.IServices
{
    public interface IWeatherService
    {
        IEnumerable<Weather> GetCities();
        Weather GetCityById(Guid id);
        void AddCity(Weather weather);


    }
}

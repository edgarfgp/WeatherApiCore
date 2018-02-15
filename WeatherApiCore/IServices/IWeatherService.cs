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
        IEnumerable<City> GetCities();
        City GetCity(Guid id);

        IEnumerable<Day> GetDaysForCity(Guid cityId);

        bool CityExists(Guid cityId);
        
        Day GetDayForCity(Guid cityId, Guid id);
        void AddCity(City weatherEntity);

       

        void AddDayForCity(Guid cityId, Day day);

        bool Save();
        IEnumerable<City> GetCities(IEnumerable<Guid> cityIds);
        void DeleteDay(Day day);
        void DeleteCity(City cityFromService);
        void UpdateDayForCity(Day dayForCityFromService);
    }
}

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

        public void AddCity(City cityEntity)
        {
            cityEntity.Id = Guid.NewGuid();
            context.Forecast.Add(cityEntity);

            if (cityEntity.Days.Any())
            {
                foreach (var day in cityEntity.Days)
                {
                    day.Id = Guid.NewGuid();
                }
            }
        }

        public Day GetDayForCity(Guid cityId, Guid id)
        {
            var days = context.Week.Where(c => c.CityId == cityId) as IEnumerable<Day>;
            var day = days.Where(d => d.Id == id).FirstOrDefault();
            return day;
        }

        public IEnumerable<Day> GetDaysForCity(Guid cityId)
        {
            var days = context.Week.Where(c => c.CityId == cityId).OrderBy(o => o.Name) as IEnumerable<Day>;
            return days;
        }


        IEnumerable<City> IWeatherService.GetCities()
        {
            return context.Forecast.OrderBy(o => o.CityName);
        }


        City IWeatherService.GetCity(Guid id)
        {
            return context.Forecast.ToList().FirstOrDefault(x => x.Id == id);
        }

        public bool Save()
        {
            return (context.SaveChanges() >= 0);
        }

        public bool CityExists(Guid cityId)
        {
            return context.Forecast.Any(i => i.Id == cityId);
        }

        public void AddDay(Guid cityId, Day dayEntity)
        {
            dayEntity.CityId = cityId;
            context.Week.Add(dayEntity);

        }

        public IEnumerable<City> GetCities(IEnumerable<Guid> cityIds)
        {
            return context.Forecast.Where(a => cityIds.Contains(a.Id))
                .OrderBy(o => o.Country)
                .OrderBy(o => o.CityName)
                .ToList();
        }
    }
}

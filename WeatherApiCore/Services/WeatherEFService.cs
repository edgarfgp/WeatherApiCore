﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApiCore.Data;
using WeatherApiCore.Entities;
using WeatherApiCore.Extensions;
using WeatherApiCore.Helpers;
using WeatherApiCore.IServices;
using WeatherApiCore.Models.Dto;

namespace WeatherApiCore.IServices
{
    public class WeatherEFService : IWeatherService
    {
        private WeatherDBContext context;

        private IPropertyMappingService propertyMappingService;
        public WeatherEFService(WeatherDBContext context, IPropertyMappingService propertyMappingService)
        {
            this.context = context;
            this.propertyMappingService = propertyMappingService;
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


        PagedList<City> IWeatherService.GetCities(CitiesResourcesParameters citiesResourcesParameters)
        {
            //var collectionBeforePaging = context.Forecast
            //    .OrderBy(o => o.CityName)
            //    .ThenBy(o => o.Country).AsQueryable();

            var collectionBeforePaging = context.Forecast.ApplySort(citiesResourcesParameters.OrderBy,
                propertyMappingService.GetPropertyMapping<CityDto, City>());



            if (!string.IsNullOrEmpty(citiesResourcesParameters.CityName))
            {
                var cityNameForWhereClause = citiesResourcesParameters.CityName
                    .Trim().ToLowerInvariant();

                collectionBeforePaging = collectionBeforePaging.Where(a => a.CityName.ToLowerInvariant() == cityNameForWhereClause);

            }
            if (!string.IsNullOrEmpty(citiesResourcesParameters.SearchQuery))
            {
                // trim & ignore casing
                var searchQueryForWhereClause = citiesResourcesParameters.SearchQuery
                    .Trim().ToLowerInvariant();

                collectionBeforePaging = collectionBeforePaging
                    .Where(a => a.CityName.ToLowerInvariant().Contains(searchQueryForWhereClause)
                    || a.Country.ToLowerInvariant().Contains(searchQueryForWhereClause));
            }

            return PagedList<City>.Create(collectionBeforePaging,
                citiesResourcesParameters.PageNumber
                , citiesResourcesParameters.PageSize);
        }


        public bool Save()
        {

            return (context.SaveChanges() >= 0);
        }

        public bool CityExists(Guid cityId)
        {
            return context.Forecast.Any(i => i.Id == cityId);
        }

        public void AddDayForCity(Guid cityId, Day dayEntity)
        {
            var city = GetCity(cityId);
            if (city != null)
            {
                if (dayEntity.Id == Guid.Empty)
                {
                    dayEntity.Id = Guid.NewGuid();
                }
                city.Days.Add(dayEntity);
            }

        }

        public City GetCity(Guid cityId)
        {
            return context.Forecast.FirstOrDefault(a => a.Id == cityId);
        }

        public IEnumerable<City> GetCities(IEnumerable<Guid> cityIds)
        {
            return context.Forecast.Where(a => cityIds.Contains(a.Id))
                .OrderBy(o => o.Country)
                .OrderBy(o => o.CityName)
                .ToList();
        }

        public void DeleteDay(Day day)
        {
            context.Week.Remove(day);
        }

        public void DeleteCity(City city)
        {
            context.Forecast.Remove(city);
        }

        public void UpdateDayForCity(Day dayForCityFromService)
        {
            //No code is Implemented
        }
    }
}

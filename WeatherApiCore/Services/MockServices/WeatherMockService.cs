using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApiCore.Entities;
using WeatherApiCore.IServices;

namespace WeatherApiCore.Services
{
    public class WeatherMockService : IWeatherService
    {
        static List<City> WeatherObjectList = new List<City>(){
                 new City
                 {
                     Id = new Guid("a6e89592-2cb2-4eac-a4b6-48a9f191811a"),
                     Country = "Spain",
                     CityName = "Barcelona",
                     Days = new List<Day>()
                     {
                            new Day
                            {
                                Id = Guid.NewGuid(),
                                Name = "Moday",
                                Description = "Clearly Day",
                                Icon = "moday.png",
                                Temp = 20,
                                CityId = new Guid("a6e89592-2cb2-4eac-a4b6-48a9f191811a"),
                                Humidity = 69,
                                TempMin = 12,
                                TempMax = 20

                            },
                             new Day
                            {
                                Id = Guid.NewGuid(),
                                Name = "Tuesday",
                                Description = "Clearly Day",
                                Icon = "tuesday.png",
                                CityId = new Guid("a6e89592-2cb2-4eac-a4b6-48a9f191811a"),
                                Temp = 12,
                                Humidity = 41,
                                TempMin = 8,
                                TempMax = 25

                            },
                              new Day
                            {
                                Id = Guid.NewGuid(),
                                Name = "Wendesday",
                                Description = "Clearly Day",
                                Icon = "wendesday.png",
                                Temp = 20,
                                Humidity = 70,
                                CityId =new Guid("a6e89592-2cb2-4eac-a4b6-48a9f191811a"),
                                TempMin = 30,
                                TempMax = 35

                            },
                               new Day
                            {
                                Id = Guid.NewGuid(),
                                Name = "Thursday",
                                Description = "Clearly Day",
                                Icon = "thursday.png",
                                Temp = 28,
                                CityId =new Guid("a6e89592-2cb2-4eac-a4b6-48a9f191811a"),
                                Humidity = 26,
                                TempMin = 18,
                                TempMax = 31

                            },
                                new Day
                            {
                                Id = Guid.NewGuid(),
                                Name = "Friday",
                                Description = "Clearly Day",
                                Icon = "friday.png",
                                Temp = 41,
                                CityId =new Guid("a6e89592-2cb2-4eac-a4b6-48a9f191811a"),
                                Humidity = 89,
                                TempMin = 30,
                                TempMax = 45

                            },
                                 new Day
                            {
                                Id = Guid.NewGuid(),
                                Name = "Saturday",
                                Description = "Clearly Day",
                                Icon = "saturday.png",
                                Temp = 20,
                                CityId =new Guid("a6e89592-2cb2-4eac-a4b6-48a9f191811a"),
                                Humidity = 58,
                                TempMin = 12,
                                TempMax = 20

                            },
                                  new Day
                            {
                                Id = Guid.NewGuid(),
                                Name = "Sunday",
                                Description = "Clearly Day",
                                Icon = "sunday.png",
                                Temp = 45,
                                CityId =new Guid("a6e89592-2cb2-4eac-a4b6-48a9f191811a"),
                                Humidity = 31,
                                TempMin = 10,
                                TempMax = 29

                            }

                     }
                 }
            };




        IEnumerable<City> IWeatherService.GetCities()
        {
            return WeatherObjectList.OrderBy(o => o.CityName);
        }


        City IWeatherService.GetCity(Guid id)
        {
            return WeatherObjectList.ToList().FirstOrDefault(city => city.Id == id);
        }

        public IEnumerable<Day> GetDaysForCity(Guid cityId)
        {
            var days = WeatherObjectList.Where(c => c.Id == cityId).OrderBy(o => o.CityName) as List<Day>; ;
            return days;
        }

        public Day GetDayForCity(Guid cityId, Guid id)
        {
            var week = WeatherObjectList.Where(w => w.Days != null) as List<Day>;
            var day = week.Where(d => d.CityId == cityId).Where(x => x.Id == id) as Day;

            return day;

        }

        public void AddCity(City weatherEntity)
        {
            WeatherObjectList.Add(weatherEntity);
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool CityExists(Guid cityId)
        {

            return WeatherObjectList.Any(c => c.Id == cityId);

        }

        public void AddDay(Guid cityId, Day day)
        {
            throw new NotImplementedException();
        }
    }
}

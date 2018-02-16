using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApiCore.Data;
using WeatherApiCore.Entities;

namespace WeatherApiCore.Extensions
{
    public static class CoreExtensions
    {

        public static void EnsureSeedDataForContext(this WeatherDBContext context)
        {
            context.Forecast.RemoveRange(context.Forecast);
            context.SaveChanges();
            var cities = new List<City>()
            {
                 new City
                    {
                        Id = new Guid("a6e89592-2cb2-4eac-a4b6-48a9f191811a"),
                        Country = "Spain",
                        CityName = "Sevilla",
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
                                CityId = new Guid("a6e89592-2cb2-4eac-a4b6-48a9f191811a"),
                                Icon = "tuesday.png",
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
                                CityId = new Guid("a6e89592-2cb2-4eac-a4b6-48a9f191811a"),
                                Temp = 20,
                                Humidity = 70,
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
                                CityId = new Guid("a6e89592-2cb2-4eac-a4b6-48a9f191811a"),
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
                                CityId = new Guid("a6e89592-2cb2-4eac-a4b6-48a9f191811a"),
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
                                CityId = new Guid("a6e89592-2cb2-4eac-a4b6-48a9f191811a"),
                                Humidity = 58,
                                TempMin = 12,
                                TempMax = 20

                            },
                                  new Day
                            {
                                Id = Guid.NewGuid(),
                                Name = "Sunday",
                                CityId = new Guid("a6e89592-2cb2-4eac-a4b6-48a9f191811a"),
                                Description = "Clearly Day",
                                Icon = "sunday.png",
                                Temp = 45,
                                Humidity = 31,
                                TempMin = 10,
                                TempMax = 29

                            }

                     }
                    },
                    new City
                    {
                        Id = new Guid("ebc8bbb8-47c2-48b1-8dce-9e46ff8b1e8f"),
                        Country = "Spain",
                        CityName = "Madrid",
                        Days = new List<Day>()
                     {
                            new Day
                            {
                                Id = Guid.NewGuid(),
                                Name = "Moday",
                                Description = "Clearly Day",
                                CityId = new Guid("ebc8bbb8-47c2-48b1-8dce-9e46ff8b1e8f"),
                                Icon = "moday.png",
                                Temp = 20,
                                Humidity = 69,
                                TempMin = 12,
                                TempMax = 20

                            },
                             new Day
                            {
                                Id = Guid.NewGuid(),
                                Name = "Tuesday",
                                Description = "Clearly Day",
                                CityId = new Guid("ebc8bbb8-47c2-48b1-8dce-9e46ff8b1e8f"),
                                Icon = "tuesday.png",
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
                                CityId = new Guid("ebc8bbb8-47c2-48b1-8dce-9e46ff8b1e8f"),
                                Temp = 20,
                                Humidity = 70,
                                TempMin = 30,
                                TempMax = 35

                            },
                               new Day
                            {
                                Id = Guid.NewGuid(),
                                Name = "Thursday",
                                Description = "Clearly Day",
                                Icon = "thursday.png",
                                CityId = new Guid("ebc8bbb8-47c2-48b1-8dce-9e46ff8b1e8f"),
                                Temp = 28,
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
                                CityId = new Guid("ebc8bbb8-47c2-48b1-8dce-9e46ff8b1e8f"),
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
                                CityId = new Guid("ebc8bbb8-47c2-48b1-8dce-9e46ff8b1e8f"),
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
                                CityId = new Guid("ebc8bbb8-47c2-48b1-8dce-9e46ff8b1e8f"),
                                Humidity = 31,
                                TempMin = 10,
                                TempMax = 29

                            }

                     }
                    },
                    new City
                    {
                        Id = new  Guid("439ae1d7-f024-4ec4-b8b2-590a10550c38"),
                        Country = "Spain",
                        CityName = "Malaga",
                        Days = new List<Day>()
                     {
                            new Day
                            {
                                Id = Guid.NewGuid(),
                                Name = "Moday",
                                Description = "Clearly Day",
                                CityId = new  Guid("439ae1d7-f024-4ec4-b8b2-590a10550c38"),
                                Icon = "moday.png",
                                Temp = 20,
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
                                CityId = new  Guid("439ae1d7-f024-4ec4-b8b2-590a10550c38"),
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
                                CityId = new  Guid("439ae1d7-f024-4ec4-b8b2-590a10550c38"),
                                Temp = 20,
                                Humidity = 70,
                                TempMin = 30,
                                TempMax = 35

                            },
                               new Day
                            {
                                Id = Guid.NewGuid(),
                                Name = "Thursday",
                                Description = "Clearly Day",
                                CityId = new  Guid("439ae1d7-f024-4ec4-b8b2-590a10550c38"),
                                Icon = "thursday.png",
                                Temp = 28,
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
                                CityId = new  Guid("439ae1d7-f024-4ec4-b8b2-590a10550c38"),
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
                                CityId = new  Guid("439ae1d7-f024-4ec4-b8b2-590a10550c38"),
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
                                Humidity = 31,
                                CityId = new  Guid("439ae1d7-f024-4ec4-b8b2-590a10550c38"),
                                TempMin = 10,
                                TempMax = 29

                            }

                     }
                    },
                    new City
                    {
                        Id = new Guid("bf387787-2c55-40fb-bb5c-8d9a139d19a6"),
                        Country = "Spain",
                        CityName = "Valencia",
                        Days = new List<Day>()
                     {
                            new Day
                            {
                                Id = Guid.NewGuid(),
                                Name = "Moday",
                                Description = "Clearly Day",
                                Icon = "moday.png",
                                Temp = 20,
                                CityId = new Guid("bf387787-2c55-40fb-bb5c-8d9a139d19a6"),
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
                                Temp = 12,
                                CityId = new Guid("bf387787-2c55-40fb-bb5c-8d9a139d19a6"),
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
                                CityId = new Guid("bf387787-2c55-40fb-bb5c-8d9a139d19a6"),
                                Humidity = 70,
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
                                CityId = new Guid("bf387787-2c55-40fb-bb5c-8d9a139d19a6"),
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
                                CityId = new Guid("bf387787-2c55-40fb-bb5c-8d9a139d19a6"),
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
                                CityId = new Guid("bf387787-2c55-40fb-bb5c-8d9a139d19a6"),
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
                                CityId = new Guid("bf387787-2c55-40fb-bb5c-8d9a139d19a6"),
                                Temp = 45,
                                Humidity = 31,
                                TempMin = 10,
                                TempMax = 29

                            }

                     }
                    },
                    new City
                    {
                        Id = new Guid("7670ab4c-c1c5-4869-bfca-0772e96252e3"),
                        Country = "Spain",
                        CityName = "Loja",
                        Days = new List<Day>()
                     {
                            new Day
                            {
                                Id = Guid.NewGuid(),
                                Name = "Moday",
                                Description = "Clearly Day",
                                CityId = new Guid("7670ab4c-c1c5-4869-bfca-0772e96252e3"),
                                Icon = "moday.png",
                                Temp = 20,
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
                                CityId = new Guid("7670ab4c-c1c5-4869-bfca-0772e96252e3"),
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
                                CityId = new Guid("7670ab4c-c1c5-4869-bfca-0772e96252e3"),
                                Humidity = 70,
                                TempMin = 30,
                                TempMax = 35

                            },
                               new Day
                            {
                                Id = Guid.NewGuid(),
                                Name = "Thursday",
                                Description = "Clearly Day",
                                CityId = new Guid("7670ab4c-c1c5-4869-bfca-0772e96252e3"),
                                Icon = "thursday.png",
                                Temp = 28,
                                Humidity = 26,
                                TempMin = 18,
                                TempMax = 31

                            },
                                new Day
                            {
                                Id = Guid.NewGuid(),
                                Name = "Friday",
                                Description = "Clearly Day",
                                CityId = new Guid("7670ab4c-c1c5-4869-bfca-0772e96252e3"),
                                Icon = "friday.png",
                                Temp = 41,
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
                                CityId = new Guid("7670ab4c-c1c5-4869-bfca-0772e96252e3"),
                                Humidity = 58,
                                TempMin = 12,
                                TempMax = 20

                            },
                                  new Day
                            {
                                Id = Guid.NewGuid(),
                                Name = "Sunday",
                                Description = "Clearly Day",
                                CityId = new Guid("7670ab4c-c1c5-4869-bfca-0772e96252e3"),
                                Icon = "sunday.png",
                                Temp = 45,
                                Humidity = 31,
                                TempMin = 10,
                                TempMax = 29

                            }

                     }

            },
                     new City
                    {
                        Id = new Guid("410abea6-b873-4eb6-a35a-229742c7d11b"),
                        Country = "Noruega",
                        CityName = "Oslo",
                        Days = new List<Day>()
                     {
                            new Day
                            {
                                Id = Guid.NewGuid(),
                                Name = "Moday",
                                Description = "Clearly Day",
                                Icon = "moday.png",
                                Temp = 20,
                                CityId = new Guid("410abea6-b873-4eb6-a35a-229742c7d11b"),
                                Humidity = 69,
                                TempMin = 12,
                                TempMax = 20

                            },
                             new Day
                            {
                                Id = Guid.NewGuid(),
                                Name = "Tuesday",
                                Description = "Clearly Day",
                                CityId = new Guid("410abea6-b873-4eb6-a35a-229742c7d11b"),
                                Icon = "tuesday.png",
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
                                CityId = new Guid("410abea6-b873-4eb6-a35a-229742c7d11b"),
                                Temp = 20,
                                Humidity = 70,
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
                                CityId = new Guid("410abea6-b873-4eb6-a35a-229742c7d11b"),
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
                                CityId = new Guid("410abea6-b873-4eb6-a35a-229742c7d11b"),
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
                                CityId = new Guid("410abea6-b873-4eb6-a35a-229742c7d11b"),
                                Humidity = 58,
                                TempMin = 12,
                                TempMax = 20

                            },
                                  new Day
                            {
                                Id = Guid.NewGuid(),
                                Name = "Sunday",
                                CityId = new Guid("410abea6-b873-4eb6-a35a-229742c7d11b"),
                                Description = "Clearly Day",
                                Icon = "sunday.png",
                                Temp = 45,
                                Humidity = 31,
                                TempMin = 10,
                                TempMax = 29

                            }

                     }
                    },
                    new City
                    {
                        Id = new Guid("258fd6db-974d-4b1f-be48-e7cdabafbbb9"),
                        Country = "United Kingdom",
                        CityName = "Manchester",
                        Days = new List<Day>()
                     {
                            new Day
                            {
                                Id = Guid.NewGuid(),
                                Name = "Moday",
                                Description = "Clearly Day",
                                CityId = new Guid("258fd6db-974d-4b1f-be48-e7cdabafbbb9"),
                                Icon = "moday.png",
                                Temp = 20,
                                Humidity = 69,
                                TempMin = 12,
                                TempMax = 20

                            },
                             new Day
                            {
                                Id = Guid.NewGuid(),
                                Name = "Tuesday",
                                Description = "Clearly Day",
                                CityId = new Guid("258fd6db-974d-4b1f-be48-e7cdabafbbb9"),
                                Icon = "tuesday.png",
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
                                CityId = new Guid("258fd6db-974d-4b1f-be48-e7cdabafbbb9"),
                                Temp = 20,
                                Humidity = 70,
                                TempMin = 30,
                                TempMax = 35

                            },
                               new Day
                            {
                                Id = Guid.NewGuid(),
                                Name = "Thursday",
                                Description = "Clearly Day",
                                Icon = "thursday.png",
                                CityId = new Guid("258fd6db-974d-4b1f-be48-e7cdabafbbb9"),
                                Temp = 28,
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
                                CityId = new Guid("258fd6db-974d-4b1f-be48-e7cdabafbbb9"),
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
                                CityId = new Guid("258fd6db-974d-4b1f-be48-e7cdabafbbb9"),
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
                                CityId = new Guid("258fd6db-974d-4b1f-be48-e7cdabafbbb9"),
                                Humidity = 31,
                                TempMin = 10,
                                TempMax = 29

                            }

                     }
                    },
                    new City
                    {
                        Id = new  Guid("b51b63e4-fce0-4073-a2cf-0506da2e1403"),
                        Country = "United Kingdom",
                        CityName = "Leicester",
                        Days = new List<Day>()
                     {
                            new Day
                            {
                                Id = Guid.NewGuid(),
                                Name = "Moday",
                                Description = "Clearly Day",
                                CityId = new  Guid("b51b63e4-fce0-4073-a2cf-0506da2e1403"),
                                Icon = "moday.png",
                                Temp = 20,
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
                                CityId = new  Guid("b51b63e4-fce0-4073-a2cf-0506da2e1403"),
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
                                CityId = new  Guid("b51b63e4-fce0-4073-a2cf-0506da2e1403"),
                                Temp = 20,
                                Humidity = 70,
                                TempMin = 30,
                                TempMax = 35

                            },
                               new Day
                            {
                                Id = Guid.NewGuid(),
                                Name = "Thursday",
                                Description = "Clearly Day",
                                CityId = new  Guid("b51b63e4-fce0-4073-a2cf-0506da2e1403"),
                                Icon = "thursday.png",
                                Temp = 28,
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
                                CityId = new  Guid("b51b63e4-fce0-4073-a2cf-0506da2e1403"),
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
                                CityId = new  Guid("b51b63e4-fce0-4073-a2cf-0506da2e1403"),
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
                                Humidity = 31,
                                CityId = new  Guid("b51b63e4-fce0-4073-a2cf-0506da2e1403"),
                                TempMin = 10,
                                TempMax = 29

                            }

                     }
                    },
                    new City
                    {
                        Id = new Guid("acc47c3a-a51a-45a7-ac27-983248e825c8"),
                        Country = "Spain",
                        CityName = "Melilla",
                        Days = new List<Day>()
                     {
                            new Day
                            {
                                Id = Guid.NewGuid(),
                                Name = "Moday",
                                Description = "Clearly Day",
                                Icon = "moday.png",
                                Temp = 20,
                                CityId = new Guid("acc47c3a-a51a-45a7-ac27-983248e825c8"),
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
                                Temp = 12,
                                CityId = new Guid("acc47c3a-a51a-45a7-ac27-983248e825c8"),
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
                                CityId = new Guid("acc47c3a-a51a-45a7-ac27-983248e825c8"),
                                Humidity = 70,
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
                                CityId = new Guid("acc47c3a-a51a-45a7-ac27-983248e825c8"),
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
                                CityId = new Guid("acc47c3a-a51a-45a7-ac27-983248e825c8"),
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
                                CityId = new Guid("acc47c3a-a51a-45a7-ac27-983248e825c8"),
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
                                CityId = new Guid("acc47c3a-a51a-45a7-ac27-983248e825c8"),
                                Temp = 45,
                                Humidity = 31,
                                TempMin = 10,
                                TempMax = 29

                            }

                     }
                    },
                    new City
                    {
                        Id = new Guid("d79aa977-6ac6-429a-a459-4c7b807de9c5"),
                        Country = "Spain",
                        CityName = "Cuenca",
                        Days = new List<Day>()
                     {
                            new Day
                            {
                                Id = Guid.NewGuid(),
                                Name = "Moday",
                                Description = "Clearly Day",
                                CityId = new Guid("d79aa977-6ac6-429a-a459-4c7b807de9c5"),
                                Icon = "moday.png",
                                Temp = 20,
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
                                CityId = new Guid("d79aa977-6ac6-429a-a459-4c7b807de9c5"),
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
                                CityId = new Guid("d79aa977-6ac6-429a-a459-4c7b807de9c5"),
                                Humidity = 70,
                                TempMin = 30,
                                TempMax = 35

                            },
                               new Day
                            {
                                Id = Guid.NewGuid(),
                                Name = "Thursday",
                                Description = "Clearly Day",
                                CityId = new Guid("d79aa977-6ac6-429a-a459-4c7b807de9c5"),
                                Icon = "thursday.png",
                                Temp = 28,
                                Humidity = 26,
                                TempMin = 18,
                                TempMax = 31

                            },
                                new Day
                            {
                                Id = Guid.NewGuid(),
                                Name = "Friday",
                                Description = "Clearly Day",
                                CityId = new Guid("d79aa977-6ac6-429a-a459-4c7b807de9c5"),
                                Icon = "friday.png",
                                Temp = 41,
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
                                CityId = new Guid("d79aa977-6ac6-429a-a459-4c7b807de9c5"),
                                Humidity = 58,
                                TempMin = 12,
                                TempMax = 20

                            },
                                  new Day
                            {
                                Id = Guid.NewGuid(),
                                Name = "Sunday",
                                Description = "Clearly Day",
                                CityId = new Guid("d79aa977-6ac6-429a-a459-4c7b807de9c5"),
                                Icon = "sunday.png",
                                Temp = 45,
                                Humidity = 31,
                                TempMin = 10,
                                TempMax = 29

                            }

                     }

            }
        };
            context.Forecast.AddRange(cities);
            context.SaveChanges();
        }
    }
}

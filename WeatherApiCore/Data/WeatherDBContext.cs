using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApiCore.Entities;
using WeatherApiCore.Models;

namespace WeatherApiCore.Data
{
    public class WeatherDBContext : DbContext
    {

        public DbSet<City> Forecast { get; set; }

        public DbSet<Day> Week { get; set; }

        public WeatherDBContext(DbContextOptions<WeatherDBContext> options)
            : base(options)
        {
        }

    }
}


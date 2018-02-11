using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApiCore.Model;

namespace WeatherApiCore.Data
{
    public class DBContext : DbContext
    {

        public DbSet<WeatherObject> WeatherForecast { get; set; }
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }

    }
}


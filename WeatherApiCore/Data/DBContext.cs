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

        public IConfiguration Config { get; set; }
        public DbSet<WeatherObject> WeatherForecast { get; set; }

        public DBContext(IConfiguration configuration)
        {
            Config = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationExtensions.GetConnectionString(Config,"LocalDB"));  
        }
    }
}


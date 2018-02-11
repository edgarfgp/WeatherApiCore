﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using WeatherApiCore.IServices;
using WeatherApiCore.Services;
using WeatherApiCore.Model;
using Microsoft.EntityFrameworkCore;
using WeatherApiCore.Data;

namespace WeatherApiCore
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //DbContext
            services.AddDbContext<DBContext>(options => options
            .UseSqlServer(Configuration.GetConnectionString("LocalDB")));
            services.AddMvc();


            //Swager Configuration
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Weather Api", Version = "V1" });
            });

            //services.AddSingleton<IWeatherService, WeatherService>();
            services.AddTransient<IWeatherService, WeatherEFService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
           


            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WeatherApi V1");
            });
        }
    }
}

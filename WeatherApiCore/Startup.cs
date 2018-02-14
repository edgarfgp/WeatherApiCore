using System;
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
using Microsoft.EntityFrameworkCore;
using WeatherApiCore.Data;
using WeatherApiCore.Models;
using WeatherApiCore.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.IO;
using WeatherApiCore.Models.OutputDto;
using WeatherApiCore.Models.InputDto;

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
            services.AddMvc(setupAction =>
            {
                setupAction.ReturnHttpNotAcceptable = true;
                setupAction.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
                setupAction.InputFormatters.Add(new XmlDataContractSerializerInputFormatter());
            });
            //DbContext
            services.AddDbContext<WeatherDBContext>(options => options
            .UseSqlServer(Configuration.GetConnectionString("LocalDB")));



            //Swager Configuration
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "Weather Api",
                    Version = "V1",
                    Description = "A Weather example ASP.NET Core Web API",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Name = "Edgar Gonzalez",
                        Email = "edgargonzalez.developer@hotmail.com",
                        Url = "https://twitter.com/efgpdev"
                    }

                });
            });

            //services.AddSingleton<IWeatherService, WeatherService>();
            services.AddScoped<IWeatherService, WeatherEFService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("An unexpected fault happened. Try again later.");

                    });
                });
            }

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<City, CityDto>()
                    .ForMember(dest => dest.Location, opt => opt.MapFrom(src =>
                    $"{src.CityName} {src.Country}"));

                cfg.CreateMap<Day, DayDto>()
                   .ForMember(dest => dest.TempMaxMin, opt => opt.MapFrom(src =>
                   $"{src.TempMin} - {src.TempMax}"));

                cfg.CreateMap<CityInputDto, City>();

                cfg.CreateMap<DayInputDto, Day>();

            });


            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WeatherApi V1");
            });
        }
    }
}

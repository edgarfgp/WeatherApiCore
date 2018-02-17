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
using WeatherApiCore.IServices;
using Microsoft.EntityFrameworkCore;
using WeatherApiCore.Data;
using WeatherApiCore.Models;
using WeatherApiCore.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.IO;
using WeatherApiCore.Models.Dto;
using WeatherApiCore.Models.CreateDto;
using WeatherApiCore.Models.UpdateDto;
using Microsoft.AspNetCore.Diagnostics;
using NLog.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using WeatherApiCore.Services;
using Newtonsoft.Json.Serialization;

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
            }).AddJsonOptions(options =>
            {

                options.SerializerSettings.ContractResolver =
                                    new CamelCasePropertyNamesContractResolver();
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

            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddScoped<IUrlHelper, UrlHelper>(implementationFactory =>
            {
                var actionContext = implementationFactory.GetService<IActionContextAccessor>().ActionContext;
                return new UrlHelper(actionContext);

            });


            services.AddTransient<IPropertyMappingService, PropertyMappingService>();

            services.AddTransient<ITypeHelperService, TypeHelperService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //loggerFactory.AddConsole();

            //loggerFactory.AddDebug(LogLevel.Information);


            //Net Core 1.0 config for 2.0 the configuration must be at Program.cs
            //loggerFactory.AddProvider(new NLog.Extensions.Logging.NLogLoggerProvider());
            //Net Core 1.0 config
            // loggerFactory.AddNLog();

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
                        var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();

                        if (exceptionHandlerFeature != null)
                        {
                            var logger = loggerFactory.CreateLogger("Global exception logger");

                            logger.LogError(500,
                                exceptionHandlerFeature.Error,
                                exceptionHandlerFeature.Error.Message);

                        }
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

                cfg.CreateMap<CityForCreateDto, City>();

                cfg.CreateMap<DayForCreateDto, Day>();

                cfg.CreateMap<DayForUpdateDto, Day>();

                cfg.CreateMap<Day, DayForUpdateDto>();

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

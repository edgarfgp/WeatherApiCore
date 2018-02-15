using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WeatherApiCore.Data;
using WeatherApiCore.Extensions;

namespace WeatherApiCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<WeatherDBContext>();
                    CoreExtensions.EnsureSeedDataForContext(context);
                    //DbInitializer.Seed(context);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error at the Initialization Database {ex.Message}");
                }
            }

            host.Run();



            // BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}

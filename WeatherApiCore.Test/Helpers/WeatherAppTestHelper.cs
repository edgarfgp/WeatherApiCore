using System;
using System.Threading.Tasks;
using Unity;
using WeatherApiCore.Extensions;
using WeatherApiCore.Helpers;
using WeatherApiCore.IServices;
using WeatherApiCore.Services;

namespace WeatherAppCoreTestHelper
{
    public class WeatherAppTestHelper
    {
        public static Task RegisterWeatherDbTest(IUnityContainer container)
        {

            var loger = new Logger<LocalMemoryRepo>();
            var repoMem = new LocalMemoryRepo(loger);

            container.RegisterRepoInstance<IDatabaseRepo>(repoMem);
            container.RegisterRepoInstance<IDatabaseRepo4Admin>(repoMem);

            return Task.CompletedTask;
        }
    }
}

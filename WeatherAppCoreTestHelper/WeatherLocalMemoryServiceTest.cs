using System;
using System.Threading.Tasks;
using Unity;

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

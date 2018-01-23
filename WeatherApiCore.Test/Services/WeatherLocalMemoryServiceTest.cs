using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Unity;
using WeatherApiCore.IServices;
using WeatherApiCore.Model;

namespace WeatherApiCore.Services.Test
{
    [TestClass]
    public class WeatherLocalMemoryServiceTest
    {

        IUnityContainer container;
        private IWeatherService _weatherService;

        [TestInitialize]
        public async Task Setup()
        {
            container = new UnityContainer();
            await WeatherAppCoreTestHelper.WeatherAppTestHelper.RegisterWeatherDbTest(container);

            container.RegisterType<IWeatherService, WeatherService>();

            _weatherService = container.Resolve<IWeatherService>();


        }

        [TestMethod]
        public async Task WeatherService_GetWeatherByLocation_ReturnWeather()
        {
            const string city = "Madrid";


            IDatabaseRepo repo = container.Resolve<IDatabaseRepo>();
            var obj = new WeatherObject
            {
                Name = city,
                Id = 3117735
            };

            var o = await repo.Create<WeatherObject>(obj);


            var ret = _weatherService.GetCities();

            var forecast = ret.Where(x => x.Name.Equals(city)).FirstOrDefault();

            Assert.AreEqual(o.Id, forecast.Id);
            Assert.AreEqual(city, forecast.Name);


        }
    }
}

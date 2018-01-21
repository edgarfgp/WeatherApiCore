using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WeatherApiCore.IServices;
using WeatherApiCore.Model;

namespace WeatherApiCore.Services.Test
{
    [TestClass]
    public class WeatherServiceTest
    {

        private Mock<IWeatherService> mockWeatherService;
        private WeatherObject weatherObject;


        [TestInitialize]
        public void Setup()
        {
            mockWeatherService = new Mock<IWeatherService>();
            weatherObject = new WeatherObject
            {
                City = "Madrid",
                Country = "Spain",
                Idiom = "Spanish",
                LocalTime = DateTime.Now,
                TemperatureMin = 5,
                TemperatureMax = 6
            };

        }

        [TestMethod]
        public void WeatherService_GetWeatherByLocation_ReturnWeather()
        {
            mockWeatherService.Setup(e => e.GetCitiesByName(It.IsAny<string>())).Returns(weatherObject);
            mockWeatherService.Verify();
            Assert.AreEqual(weatherObject.City, "Madrid");
        }
    }
}

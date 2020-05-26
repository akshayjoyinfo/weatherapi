using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAPIChallenge.Interfaces;
using WeatherAPIChallenge.Services;
using Xunit;

namespace WeatherAPIChallenge.Tests.Services
{
    public class TemperatureServiceShould:IDisposable
    {
        static Mock<IWeatherAPI> _weatherAPI;
        static TemperatureService temperatureService;

        public TemperatureServiceShould()
        {
            _weatherAPI = new Mock<IWeatherAPI>();
            temperatureService = new TemperatureService(_weatherAPI.Object);

        }

        public void Dispose()
        {
            _weatherAPI = null;
            temperatureService = null;
        }

        [Fact]
        public async void GetMultipleCitiesWeatherReports()
        {
            _weatherAPI.Setup(x => x.GetWeatherInfo("Goa")).Returns(Task.FromResult(new DTO.WeatherAPIResponseData() { Name = "Goa", Main = new DTO.Main() { Temp = 25.65 } } ));
            _weatherAPI.Setup(x => x.GetWeatherInfo("London")).Returns(Task.FromResult(new DTO.WeatherAPIResponseData() { Name = "London", Main = new DTO.Main() { Temp = 75.65 } }));

            var result = await temperatureService.ProcesRequests(new List<string>() { "Goa", "London" });

            Assert.NotNull(result);
            //highest will be he fierst element
            Assert.Equal(75.65, result.First().temp);
        }
    }
}

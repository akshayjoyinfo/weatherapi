
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherAPIChallenge.Services;
using Xunit;

namespace WeatherAPIChallenge.Tests.Services
{
    public class WeatherAPIServiceShould : IDisposable
    {
        static Mock<IConfiguration> _configuraiton;
        static HttpClient _httpClient;
        static WeatherAPI _weatherAPI;

        public WeatherAPIServiceShould()
        {
            _httpClient = new HttpClient();
            _configuraiton = new Mock<IConfiguration>();
            _weatherAPI = new WeatherAPI(_httpClient, _configuraiton.Object);
        }

        [Fact]
        public async Task ExecuteGetWeatherInfoSuccessfully()
        {
            //setup
            _configuraiton.Setup(c => c.GetSection(It.IsAny<String>())).Returns(new Mock<IConfigurationSection>().Object);

            var result = await _weatherAPI.GetWeatherInfo("Goa");

            Assert.NotNull(result);

        }


        public void Dispose()
        {
            _configuraiton = null;
            _httpClient = null;
            _weatherAPI = null;

        }
    }
}

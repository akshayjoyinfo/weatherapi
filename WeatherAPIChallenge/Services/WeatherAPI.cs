using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherAPIChallenge.Domain;
using WeatherAPIChallenge.DTO;
using WeatherAPIChallenge.Interfaces;

namespace WeatherAPIChallenge.Services
{
    public class WeatherAPI:IWeatherAPI
    {
        private HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private string RemoteURL = "";

        public WeatherAPI(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            
        }

        public async Task<WeatherAPIResponseData> GetWeatherInfo(string city)
        {
            RemoteURL = _configuration.GetValue<string>("WeatherRemoteURL")!=null ? _configuration.GetValue<string>("WeatherRemoteURL"): "https://openweathermap.org/data/2.5/weather?q={0}&appid=439d4b804bc8187953eb36d2a8c26a02";
            _httpClient = new HttpClient();
            string responseString = string.Empty;
            // List<WeatherResponse> weatherResponses = new List<WeatherResponse>();
            List<string> weatherResponses = new List<string>();

            var url = string.Format(RemoteURL, city);
            _httpClient.BaseAddress = new Uri(url);
            responseString = await _httpClient.GetStringAsync(url);

            var weatherReponse = JsonConvert.DeserializeObject<WeatherAPIResponseData>(responseString);

            return weatherReponse;

        }

        
    }
}

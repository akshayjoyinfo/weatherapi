using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WeatherAPIChallenge.Domain;
using WeatherAPIChallenge.DTO;
using WeatherAPIChallenge.Interfaces;

namespace WeatherAPIChallenge.Services
{
    public class TemperatureService:ITemperatureService
    {
        private readonly IWeatherAPI _weatherAPI;

        public TemperatureService(IWeatherAPI weatherAPI)
        {
            _weatherAPI = weatherAPI;
        }

        public async Task<List<WeatherResponse>> ProcesRequests(List<string> cities)
        {
            List<WeatherAPIResponseData> weatherResponses = new List<WeatherAPIResponseData>();
            List<WeatherResponse> finalWeatherResponses = new List<WeatherResponse>();
            var index = 1;
            foreach(var city in cities)
            {
                var result = await _weatherAPI.GetWeatherInfo(city);
                weatherResponses.Add(result);
               finalWeatherResponses.Add(new WeatherResponse() { index = index, name = result.Name, temp = result.Main.Temp });
                index++;
            }


            // Soting
            ///Expression/ ="name"
            var param = "temp";
            var propertyInfo = typeof(WeatherResponse).GetProperty(param);

            //return finalWeatherResponses.OrderByDescending(o => o.temp).ToList();
            return finalWeatherResponses.OrderByDescending(x => propertyInfo.GetValue(x, null)).ToList();

            //return finalWeatherResponses.OrderByDescending(o => o.temp).ToList();
        }
    }
}

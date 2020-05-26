using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherAPIChallenge.DTO;

namespace WeatherAPIChallenge.Interfaces
{
    public interface IWeatherAPI
    {
        Task<WeatherAPIResponseData> GetWeatherInfo(string city);
    }
}

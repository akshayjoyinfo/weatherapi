using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherAPIChallenge.Domain;
using WeatherAPIChallenge.DTO;

namespace WeatherAPIChallenge.Interfaces
{
    public interface ITemperatureService
    {
        Task<List<WeatherResponse>> ProcesRequests(List<string> cities);
    }
}

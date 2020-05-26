using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAPIChallenge.Domain
{
    public class WeatherResponse
    {
        public int index { get; set; }
        public string name { get; set; }
        public double temp { get; set; }
    }
}

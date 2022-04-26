using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherConcurrentApp.Domain.Entities;
using WeatherConcurrentApp.Domain.Interfaces;

namespace WeatherConcurrencyApp.Infrastructure.OpenWeatherClient
{
    public class weatherfoilestream : IHttpOpenWeatherClient
    {
        public Task<OpenWeather> GetWeatherByCityNameAsync(string city)
        {
            throw new NotImplementedException();
        }
    }
}

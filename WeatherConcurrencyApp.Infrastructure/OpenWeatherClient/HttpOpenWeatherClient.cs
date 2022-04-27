using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherConcurrencyApp.Common;
using WeatherConcurrentApp.Domain.Entities;
using WeatherConcurrentApp.Domain.Interfaces;
using Newtonsoft.Json;
using System.IO;

namespace WeatherConcurrencyApp.Infrastructure.OpenWeatherClient
{
    public class HttpOpenWeatherClient : IHttpOpenWeatherClient
    {
        public async Task<OpenWeather> GetWeatherByCityNameAsync(string city)
        {
            string url = $"{AppSettings.ApiUrl}{city}&units={AppSettings.units}&lang=sp&appid={AppSettings.Token}";
            string jsonObject = string.Empty;
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    jsonObject = await httpClient.GetAsync(url).Result.Content.ReadAsStringAsync();
                    
                }
                Extraer();
                if (string.IsNullOrEmpty(jsonObject))
                {
                    throw new NullReferenceException("El objeto json no puede ser null.");
                }

                return Newtonsoft.Json.JsonConvert.DeserializeObject<OpenWeather>(jsonObject);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Extraer()
        {
            string j = @"\Weather - Hilos\WeatherConcurrencyApp.Infrastructure\Cities.json";
            string path=Path.GetFullPath("a");
            //path = string.Join("", path.Split("\Weather-Hilos\WeatherConcurrencyApp\bin\Debug\a"));

            Console.WriteLine(path+j);
            if (File.Exists(path) == true)
            {
                Console.WriteLine("Si existe");
            }
            else
                Console.WriteLine("No existe");

            string jsonString = string.Empty;
            OpenWeather openWeather = JsonConvert.DeserializeObject<OpenWeather>(jsonString);
            Console.WriteLine(jsonString);
        }
    }
}







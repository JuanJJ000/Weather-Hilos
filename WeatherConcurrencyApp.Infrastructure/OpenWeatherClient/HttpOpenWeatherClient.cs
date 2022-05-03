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
          
                using (HttpClient httpClient = new HttpClient())
                {
                    jsonObject = await httpClient.GetAsync(url).Result.Content.ReadAsStringAsync();
                    
                }
            
                if (string.IsNullOrEmpty(jsonObject))
                {
                    throw new NullReferenceException("El objeto json no puede ser null.");
                }

                return JsonConvert.DeserializeObject<OpenWeather>(jsonObject);
            
            
        }
      

        public DateTime En_tiempo(long g)
        {
            {
                DateTime day = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).ToLocalTime();
                day = day.AddSeconds(g).ToLocalTime();

                return day;
            }
        }

        public List<OpenWeather> GetCityNames()
        {

            string j = @"\WeatherConcurrencyApp.Infrastructure\Cities.json";
            string path = Path.GetFullPath("Cities.json").Replace(@"\WeatherConcurrencyApp\bin\Debug\Cities.json", string.Empty) + j;


            if (File.Exists(path) == false)
            {
                Console.WriteLine("No existe");



            }
            else
                Console.WriteLine("Si existe");
            var jsonString = File.ReadAllText(path);
            List<OpenWeather> openWeathers = JsonConvert.DeserializeObject<List<OpenWeather>>(jsonString);



            return openWeathers;
        }

        public OpenWeather GetWeatherByCity(OpenWeather openWeather)
        {



            return openWeather;

        }



    }
}







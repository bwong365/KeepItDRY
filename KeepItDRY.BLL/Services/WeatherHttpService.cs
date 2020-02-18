using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace KeepItDRY.BLL.Services
{
    public class WeatherHttpService
    {
        private HttpClient _http;

        public WeatherHttpService(HttpClient http)
        {
            _http = http;
        }

        public async void GetWeatherForPetAsync()
        {
            var response = await _http.GetAsync()
        }
    }
}

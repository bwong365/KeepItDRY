using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using KeepItDRY.BLL.Models;
using Microsoft.Extensions.Configuration;

namespace KeepItDRY.BLL.Services
{
    public class WeatherHttpService
    {
        private HttpClient _http;
        private string _apiKey;

        public WeatherHttpService(HttpClient http, IConfiguration configuration)
        {
            _http = http;
            _http.BaseAddress = new Uri("http://dataservice.accuweather.com/");
            _apiKey = configuration["WeatherApiKey"];
        }

        public async Task<string> FetchWeatherForPet()
        {
            try
            {
                var locationCode = (await FetchLocationCodeForPet("S4N0Z8"))[0].Key;
                return (await FetchWeatherForLocationCode(locationCode))[0].WeatherText;
            }
            catch
            {
                throw;
            }
        }

        private async Task<List<LocationCodeResponse>> FetchLocationCodeForPet(string postalCode)
        {
            var response = await _http.GetAsync($"/locations/v1/postalcodes/CA/search?apikey={_apiKey}&q={postalCode.Replace(" ", "")}");
            return await HandleResponse<LocationCodeResponse>(response);
        }

        private async Task<List<CurrentConditionsResponse>> FetchWeatherForLocationCode(string code)
        {
            var response = await _http.GetAsync($"/currentconditions/v1/{code}?apikey={_apiKey}");
            return await HandleResponse<CurrentConditionsResponse>(response);
        }

        private async Task<List<T>> HandleResponse<T>(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException("Failed to reach weather service");
            }
            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<List<T>>(responseStream);
        }
    }
}

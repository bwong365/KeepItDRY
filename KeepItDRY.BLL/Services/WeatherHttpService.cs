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
        public event EventHandler<AddressUpdateEventArgs> AddressFound;


        public WeatherHttpService(HttpClient http, IConfiguration configuration)
        {
            _http = http;
            _http.BaseAddress = new Uri("http://dataservice.accuweather.com/");
            _apiKey = configuration["WeatherApiKey"];
        }

        public async Task<CurrentConditionsResponse> FetchWeatherForPostalCode(string postalCode)
        {
            try
            {
                var locationCode = (await FetchLocationCode(postalCode)).Key;
                return await FetchWeatherForLocationCode(locationCode);
            }
            catch
            {
                throw;
            }
        }

        private async Task<LocationCodeResponse> FetchLocationCode(string postalCode)
        {
            var response = await _http.GetAsync($"/locations/v1/postalcodes/CA/search?apikey={_apiKey}&q={postalCode.Replace(" ", "")}");
            var locationData = await HandleResponse<LocationCodeResponse>(response);
            AddressFound?.Invoke(this, new AddressUpdateEventArgs
            {
                PostalCode = postalCode,
                City = locationData.ParentCity.EnglishName,
                Province = locationData.AdministrativeArea.EnglishName
            });
            return locationData;
        }

        private async Task<CurrentConditionsResponse> FetchWeatherForLocationCode(string code)
        {
            var response = await _http.GetAsync($"/currentconditions/v1/{code}?apikey={_apiKey}");
            return await HandleResponse<CurrentConditionsResponse>(response);
        }

        private async Task<T> HandleResponse<T>(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException("Failed to reach weather service");
            }
            using var responseStream = await response.Content.ReadAsStreamAsync();
            return (await JsonSerializer.DeserializeAsync<List<T>>(responseStream))[0];
        }
    }
}

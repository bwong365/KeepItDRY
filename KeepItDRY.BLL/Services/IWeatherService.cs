using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using KeepItDRY.BLL.Models;

namespace KeepItDRY.BLL.Services
{
    public interface IWeatherService
    {
        Task<WeatherStatus> FetchWeatherForAddress(int addressId);
        Task<WeatherStatus> FetchWeatherForPet(int petId);
    }
}

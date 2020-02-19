using System.Threading.Tasks;
using AutoMapper;
using KeepItDRY.BLL.Models;
using KeepItDRY.DAL.Repositories;

namespace KeepItDRY.BLL.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IPetRepository _petRepo;
        private readonly IAddressRepository _addressRepo;
        private readonly IMapper _mapper;
        private readonly WeatherHttpService _weatherHttp;

        public WeatherService(IPetRepository petRepo,
                              IAddressRepository addressRepo,
                              IMapper mapper,
                              WeatherHttpService weatherHttp)
        {
            _petRepo = petRepo;
            _addressRepo = addressRepo;
            _mapper = mapper;
            _weatherHttp = weatherHttp;
        }

        public async Task<WeatherStatus> FetchWeatherForPet(int petId)
        {
            var pet = _mapper.Map<Pet>(_petRepo.GetById(petId));
            if (pet.Address == null)
            {
                return null;
            }
            int addressId = pet.Address.Id;
            return await FetchWeatherForAddress(addressId);
        }

        public async Task<WeatherStatus> FetchWeatherForAddress(int addressId)
        {
            var address = _mapper.Map<Address>(_addressRepo.GetByIdNoTracking(addressId));
            if (string.IsNullOrWhiteSpace(address.City))
            {
                _weatherHttp.AddressFound += (sender, addressUpdate) => UpdateAddress(addressUpdate, address);
            }
            // change to weather object
            var currentConditions = await _weatherHttp.FetchWeatherForPostalCode(address.PostalCode);
            return _mapper.Map<WeatherStatus>(currentConditions);
        }

        private void UpdateAddress(AddressUpdateEventArgs addressUpdate, Address address)
        {
            address.City = addressUpdate.City;
            address.Province = addressUpdate.Province;
            _addressRepo.Update(_mapper.Map<DAL.Entities.Address>(address));
        }
    }
}

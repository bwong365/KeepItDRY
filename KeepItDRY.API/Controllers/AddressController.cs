using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using KeepItDRY.API.DTO;
using KeepItDRY.BLL.Models;
using KeepItDRY.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace KeepItDRY.Controllers
{
    [ApiController]
    [Route("api/owners/{ownerId}/addresses")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        private readonly IOwnerService _ownerService;
        private readonly IWeatherService _weatherService;
        IMapper _mapper;

        public AddressController(IAddressService addressService,
                                  IOwnerService ownerService,
                                  IWeatherService weatherService,
                                  IMapper mapper)
        {
            _addressService = addressService;
            _ownerService = ownerService;
            _weatherService = weatherService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<Address>> GetAllAddresss(int ownerId)
        {
            var addresses = _addressService.GetAllAddressesForOwnerId(ownerId);
            return addresses;
        }

        [HttpPost]
        public ActionResult AddAddress(int ownerId, [FromBody] AddressInputDto addressInput)
        {
            if (!_ownerService.Exists(ownerId))
            {
                return BadRequest("Incorrect Address Type");
            }
            var address = _mapper.Map<Address>(addressInput);
            address.Id = 0;
            address.OwnerId = ownerId;
            var newId = _addressService.Update(address);
            address.Id = newId;
            return CreatedAtRoute("GetAddressForOwner", new { ownerId, addressId = newId }, address);
        }

        [HttpGet("{addressId:int}", Name = "GetAddressForOwner")]
        public ActionResult<Address> GetAddress(int ownerId, int addressId)
        {
            if (!_ownerService.Exists(ownerId))
            {
                return BadRequest();
            }
            var address = _addressService.GetById(addressId);
            if (address == null || address.OwnerId != ownerId)
            {
                return NotFound();
            }
            return address;
        }

        [HttpPut("{addressId:int}")]
        public ActionResult UpdateAddress(int ownerId, int addressId, [FromBody] AddressInputDto addressInput)
        {
            if (!_addressService.OwnerOwnsAddress(ownerId, addressId))
            {
                return BadRequest();
            }
            var address = _mapper.Map<Address>(addressInput);
            address.Id = addressId;
            address.OwnerId = ownerId;
            _addressService.Update(address);
            return NoContent();
        }

        [HttpDelete("{addressId:int}")]
        public ActionResult DeleteAddress(int ownerId, int addressId)
        {
            if (!_addressService.OwnerOwnsAddress(ownerId, addressId))
            {
                return BadRequest();
            }
            _addressService.Delete(addressId);
            return NoContent();
        }

        [HttpGet("{addressId:int}/status")]
        public async Task<ActionResult<WeatherStatus>> GetAddressStatus(int ownerId, int addressId)
        {
            if (!_addressService.OwnerOwnsAddress(ownerId, addressId))
            {
                return BadRequest();
            }
            return await _weatherService.FetchWeatherForAddress(addressId);
        }
    }
}
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
    [Route("api/owners/{ownerId}/pets")]
    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;
        private readonly IOwnerService _ownerService;
        private readonly IWeatherService _weatherService;
        private readonly IMapper _mapper;

        public PetController(IPetService petService,
                                  IMapper mapper,
                                  IOwnerService ownerService,
                                  IWeatherService weatherService)
        {
            _petService = petService;
            _ownerService = ownerService;
            _weatherService = weatherService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<PetDTO>> GetAllPets(int ownerId)
        {
            var pets = _ownerService.GetAllPets(ownerId);
            return _mapper.Map<List<PetDTO>>(pets);
        }

        [HttpPost]
        public ActionResult AddPet(int ownerId, [FromBody] PetDTO petDto)
        {
            if (!petDto.HasValidPetType() || !_ownerService.Exists(ownerId))
            {
                return BadRequest("Incorrect Pet Type");
            }
            var pet = _mapper.Map<Pet>(petDto);
            pet.Id = 0;
            pet.OwnerId = ownerId;
            int newId = _petService.Update(pet);
            petDto.Id = newId;
            return CreatedAtRoute("GetPetForOwner", new { ownerId, petId = newId }, petDto);
        }

        [HttpGet("{petId:int}", Name = "GetPetForOwner")]
        public ActionResult<PetDTO> GetPet(int ownerId, int petId)
        {
            if (!_ownerService.Exists(ownerId))
            {
                return BadRequest();
            }
            var pet = _mapper.Map<PetDTO>(_petService.GetById(petId));
            if (pet == null || pet.OwnerId != ownerId)
            {
                return NotFound();
            }
            return pet;
        }

        [HttpPut("{petId:int}")]
        public ActionResult UpdatePet(int ownerId, int petId, [FromBody] PetDTO petDto)
        {
            if (!_ownerService.OwnerOwnsPet(ownerId, petId))
            {
                return BadRequest();
            }
            petDto.Id = petId;
            petDto.OwnerId = ownerId;
            _petService.Update(_mapper.Map<Pet>(petDto));
            return NoContent();
        }

        [HttpDelete("{petId:int}")]
        public ActionResult DeletePet(int ownerId, int petId)
        {
            if (!_ownerService.OwnerOwnsPet(ownerId, petId))
            {
                return BadRequest();
            }
            _petService.Delete(petId);
            return NoContent();
        }

        [HttpGet("{petId:int}/status")]
        public async Task<ActionResult<WeatherStatus>> GetPetStatus(int ownerId, int petId)
        {
            if (!_ownerService.OwnerOwnsPet(ownerId, petId))
            {
                return BadRequest();
            }
            var weatherStatus = await _weatherService.FetchWeatherForPet(petId);
            if (weatherStatus == null) {
                return NotFound();
            }
            return weatherStatus;
        }
    }
}
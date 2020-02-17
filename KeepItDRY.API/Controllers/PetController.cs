using System;
using System.Collections.Generic;
using AutoMapper;
using KeepItDRY.API.DTO;
using KeepItDRY.BLL.Models;
using KeepItDRY.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace KeepItDRY.Controllers
{
    [Route("api/pets")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;
        private readonly IMapper _mapper;

        public PetController(IPetService petService, IMapper mapper)
        {
            _petService = petService ?? throw new ArgumentNullException("PetService");
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<PetDTO>> GetAllPets()
        {
            var pets = _petService.GetListByAll();
            return Ok(_mapper.Map<List<PetDTO>>(pets));
        }

        [HttpPost]
        public ActionResult AddPet([FromBody] PetDTO petDto)
        {
            if (!petDto.HasValidPetType())
            {
                return BadRequest("Incorrect Pet Type");
            }
            var pet = _mapper.Map<IPet>(petDto);
            pet.Id = 0;
            int newId = _petService.Update(pet);
            petDto.Id = newId;
            return CreatedAtRoute("GetPet", new { Id = newId }, petDto);
        }

        [HttpGet("{Id:int}", Name="GetPet")]
        public ActionResult<PetDTO> GetPet(int Id)
        {
            if (!_petService.Exists(Id))
            {
                return NotFound();
            }
            var pet = _mapper.Map<PetDTO>(_petService.Get(Id));
            return Ok(pet);
        }

        [HttpPut("{Id:int}")]
        public ActionResult UpdatePet(int Id, [FromBody] PetDTO petDto)
        {
            if (!_petService.Exists(Id))
            {
                return BadRequest();
            }
            petDto.Id = Id;
            _petService.Update(_mapper.Map<IPet>(petDto));
            return NoContent();
        }

        [HttpDelete("{Id:int}")]
        public ActionResult DeletePet(int Id)
        {
            if (!_petService.Exists(Id))
            {
                return BadRequest();
            }
            _petService.Delete(Id);
            return NoContent();
        }
    }
}
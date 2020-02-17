using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KeepItDRY.BLL.Models;
using KeepItDRY.BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KeepItDRY.Controllers
{
    [Route("api/pets")]
    [ApiController]
    public class PetController : ControllerBase
    {
        IPetService _petService;

        public PetController(IPetService petService)
        {
            _petService = petService ?? throw new ArgumentNullException(nameof(petService));
        }

        [HttpGet]
        public ActionResult<List<Pet>> GetAllPets()
        {
            return Ok(_petService.GetListByAll());
        }

        [HttpPost]
        public ActionResult AddPet([FromBody] Pet pet)
        {
            pet.Id = 0;
            int newId = _petService.Update(pet);
            return CreatedAtRoute("GetPet", new { Id = newId });
        }

        [HttpGet("{Id:int}", Name = "GetPet")]
        public ActionResult<Pet> GetPet(int Id)
        {
            var pet = _petService.Get(Id);
            return Ok(pet);
        }
    }
}
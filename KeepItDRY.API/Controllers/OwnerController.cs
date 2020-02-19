using System.Collections.Generic;
using AutoMapper;
using KeepItDRY.API.DTO;
using KeepItDRY.BLL.Models;
using KeepItDRY.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace KeepItDRY.API.Controllers
{
    [ApiController]
    [Route("api/owners")]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;
        IMapper _mapper;

        public OwnerController(IOwnerService ownerService, IMapper mapper)
        {
            _ownerService = ownerService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<Owner>> GetOwners() => _ownerService.GetListByAll();

        [HttpPost]
        public ActionResult AddOwner([FromBody] Owner owner)
        {
            owner.Id = 0;
            int newId = _ownerService.Update(owner);
            owner.Id = newId;
            return CreatedAtRoute("GetOwner", new { id = newId }, owner);
        }

        [HttpGet("{id:int}", Name = "GetOwner")]
        public ActionResult<OwnerDTO> GetOwner(int id, [FromQuery] bool withPets = false)
        {
            if (!_ownerService.Exists(id))
            {
                return NotFound();
            }

            Owner owner;
            if (withPets)
            {
                owner = _ownerService.GetOwnerWithPets(id);
            }
            else
            {
                owner = _ownerService.GetById(id);
            }
            return _mapper.Map<OwnerDTO>(owner);
        }

        [HttpPut("{id:int}")]
        public ActionResult UpdateOwner(int id, [FromBody] Owner owner)
        {
            if (!_ownerService.Exists(id))
            {
                return BadRequest();
            }
            owner.Id = id;
            _ownerService.Update(owner);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public ActionResult DeleteOwner(int id)
        {
            if (!_ownerService.Exists(id))
            {
                return BadRequest();
            }
            _ownerService.Delete(id);
            return NoContent();
        }
    }
}
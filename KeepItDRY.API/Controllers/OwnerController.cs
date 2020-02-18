using System.Collections.Generic;
using KeepItDRY.BLL.Services;
using KeepItDRY.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KeepItDRY.API.Controllers
{
    [ApiController]
    [Route("api/owners")]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
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
        public ActionResult<Owner> GetOwner(int id) => _ownerService.GetById(id);

    }
}
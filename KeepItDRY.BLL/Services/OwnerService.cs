using System;
using System.Collections.Generic;
using AutoMapper;
using KeepItDRY.BLL.Models;
using KeepItDRY.DAL.Repositories;

namespace KeepItDRY.BLL.Services
{
    public class OwnerService : IOwnerService
    {
        IOwnerRepository _repo;
        IMapper _mapper;

        public OwnerService(IOwnerRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public void Delete(int Id) => _repo.Delete(Id);
        public bool Exists(int Id) => _repo.Exists(Id);
        public Owner GetById(int Id) => _mapper.Map<Owner>(_repo.GetById(Id));
        public List<Pet> GetAllPets(int ownerId) => _mapper.Map<List<Pet>>(_repo.GetAllPets(ownerId));
        public List<Owner> GetListByAll() => _mapper.Map<List<Owner>>(_repo.GetListByAll());
        public Owner GetOwnerWithPets(int Id) => _mapper.Map<Owner>(_repo.GetOwnerWithPets(Id));
        public int Update(Owner newOwner)
        {
            var owner = _repo.GetById(newOwner.Id);
            if (owner == null)
            {
                owner = _mapper.Map<DAL.Entities.Owner>(newOwner);
            }
            else
            { 
                _mapper.Map(newOwner, owner);
            }
            return _repo.Update(owner);
        }
        public bool OwnerOwnsPet(int ownerId, int petId) => _repo.OwnerOwnsPet(ownerId, petId);
    }
}

using System;
using System.Collections.Generic;
using AutoMapper;
using KeepItDRY.BLL.Models;
using KeepItDRY.DAL.Repositories;

namespace KeepItDRY.BLL.Services
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _repo;
        private readonly IMapper _mapper;

        public PetService(IPetRepository repo, IMapper mapper)
        {
            _repo = repo ?? throw new ArgumentNullException("Pet Repository");
            _mapper = mapper ?? throw new ArgumentNullException("AutoMapper");
        }

        public void Delete(int Id) => _repo.Delete(Id);

        public Pet GetById(int Id) => _mapper.Map<Pet>(_repo.GetById(Id));

        public List<Pet> GetListByAll() => _mapper.Map<List<Pet>>(_repo.GetListByAll());

        public bool Exists(int Id) => _repo.Exists(Id);

        public int Update(Pet pet)
        {
            var petEntity = _repo.GetById(pet.Id);
            if (petEntity == null)
            {
                petEntity = _mapper.Map<DAL.Entities.Pet>(pet);
            }
            else
            {
                _mapper.Map(pet, petEntity);
            }
            return _repo.Update(petEntity);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using AutoMapper;
using KeepItDRY.BLL.Models;
using KeepItDRY.DAL;

namespace KeepItDRY.BLL.Services
{
    public class PetService : IPetService
    {
        private readonly IRepository<DAL.Entities.Pet> _repo;
        private readonly IMapper _mapper;

        public PetService(IRepository<DAL.Entities.Pet> repo, IMapper mapper)
        {
            _repo = repo ?? throw new ArgumentNullException("Pet Repository");
            _mapper = mapper ?? throw new ArgumentNullException("AutoMapper");
        }

        public void Delete(int Id) => _repo.Delete(Id);

        public Pet Get(int Id) => _mapper.Map<Pet>(_repo.Get(Id));

        public List<Pet> GetListByAll() => _mapper.Map<List<Pet>>(_repo.GetListByAll());

        public bool Exists(int Id) => _repo.Exists(Id);

        public int Update(Pet pet)
        {
            var petEntity = _repo.Get(pet.Id);
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

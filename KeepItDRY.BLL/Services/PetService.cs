using System;
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

        public IPet Get(int Id) => _mapper.Map<IPet>(_repo.Get(Id));

        public List<IPet> GetListByAll() => _mapper.Map<List<IPet>>(_repo.GetListByAll());

        public bool Exists(int Id) => _repo.Exists(Id);

        public int Update(IPet pet)
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

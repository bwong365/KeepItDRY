using System;
using System.Collections.Generic;
using AutoMapper;
using KeepItDRY.BLL.Models;
using KeepItDRY.DAL.Repositories;

namespace KeepItDRY.BLL.Services
{
    public class AddressService : IAddressService
    {
        private readonly IMapper _mapper;
        private readonly IAddressRepository _repo;

        public AddressService(IAddressRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public void Delete(int Id)
        {
            if (!_repo.Exists(Id))
            {
                throw new MissingMemberException();
            }
            _repo.Delete(Id);
        }

        public bool Exists(int Id) => _repo.Exists(Id);

        public Address GetById(int Id) => _mapper.Map<Address>(_repo.GetById(Id));

        public List<Address> GetListByAll() => _mapper.Map<List<Address>>(_repo.GetListByAll());

        public List<Address> GetAllAddressesForOwnerId(int ownerId) => _mapper.Map<List<Address>>(_repo.GetAllAddressesForOwnerId(ownerId));

        public int Update(Address address)
        {
            var addressEntity = _repo.GetById(address.Id);
            if (addressEntity == null)
            {
                addressEntity = _mapper.Map<DAL.Entities.Address>(address);
            }
            else
            {
                _mapper.Map(address, addressEntity);
            }
            return _repo.Update(addressEntity);
        }

        public bool OwnerOwnsAddress(int ownerId, int addressId) => _repo.OwnerOwnsAddress(ownerId, addressId);
    }
}

using System.Collections.Generic;
using KeepItDRY.DAL.Entities;

namespace KeepItDRY.DAL.Repositories
{
    public interface IAddressRepository : IRepository<Address>
    {
        List<Address> GetAllAddressesForOwnerId(int ownerId);
        bool OwnerOwnsAddress(int ownerId, int addressId);
        Address GetByIdNoTracking(int addressId);
    }
}

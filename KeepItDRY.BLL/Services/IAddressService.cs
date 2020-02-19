using System.Collections.Generic;
using KeepItDRY.BLL.Models;

namespace KeepItDRY.BLL.Services
{
    public interface IAddressService : IService<Address>
    {
        List<Address> GetAllAddressesForOwnerId(int ownerId);
        bool OwnerOwnsAddress(int ownerId, int addressId);
    }
}

using System.Collections.Generic;
using System.Linq;
using KeepItDRY.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace KeepItDRY.DAL.Repositories
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        public AddressRepository(KeepItDRYContext context) : base(context) { }

        public List<Address> GetAllAddressesForOwnerId(int ownerId) => _context.Addresses.Where(a => a.OwnerId == ownerId).ToList();
        public Address GetByIdNoTracking(int addressId) => _context.Addresses.AsNoTracking().FirstOrDefault(a => a.Id == addressId);
        public bool OwnerOwnsAddress(int ownerId, int addressId) => _context.Addresses.Where(a => a.Id == addressId).Select(a => a.OwnerId == ownerId).FirstOrDefault();
    }
}

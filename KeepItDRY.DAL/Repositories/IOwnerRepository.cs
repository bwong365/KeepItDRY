using System.Collections.Generic;
using KeepItDRY.DAL.Entities;

namespace KeepItDRY.DAL.Repositories
{
    public interface IOwnerRepository : IRepository<Owner> {
        List<Pet> GetAllPets(int ownerId);
        Owner GetOwnerWithPets(int ownerId);
        bool OwnerOwnsPet(int ownerId, int petId);
    }
}

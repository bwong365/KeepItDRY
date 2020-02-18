using System.Collections.Generic;
using KeepItDRY.DAL.Entities;

namespace KeepItDRY.BLL.Services
{
    public interface IOwnerService : IService<Owner> {
        List<Pet> GetAllPets(int ownerId);
        bool OwnerOwnsPet(int ownerId, int petId);
    }
}

using System.Collections.Generic;
using KeepItDRY.BLL.Models;

namespace KeepItDRY.BLL.Services
{
    public interface IOwnerService : IService<Owner> {
        List<Pet> GetAllPets(int ownerId);
        Owner GetOwnerWithPets(int Id);
        bool OwnerOwnsPet(int ownerId, int petId);
    }
}

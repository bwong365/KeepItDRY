using System.Collections.Generic;
using System.Linq;
using KeepItDRY.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace KeepItDRY.DAL.Repositories
{
    public class OwnerRepository : BaseRepository<Owner>, IOwnerRepository
    {
        public OwnerRepository(KeepItDRYContext context) : base(context) { }

        public List<Pet> GetAllPets(int ownerId) => _context.Set<Owner>()
                                                            .Where(o => o.Id == ownerId)
                                                            .SelectMany(o => o.Pets).ToList();

        public bool OwnerOwnsPet(int ownerId, int petId) => _context.Set<Owner>()
                                                                    .Where(o => o.Id == ownerId)
                                                                    .SelectMany(o => o.Pets)
                                                                    .Any(p => p.Id == petId);

        public Owner GetOwnerWithPets(int ownerId) => _context.Set<Owner>().Where(o => o.Id == ownerId).Include(o => o.Pets).FirstOrDefault();
    }
}

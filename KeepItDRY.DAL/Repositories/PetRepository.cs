using KeepItDRY.DAL.Entities;

namespace KeepItDRY.DAL.Repositories
{
    public class PetRepository : BaseRepository<Pet>, IPetRepository
    {
        public PetRepository(KeepItDRYContext context) : base(context) { }
    }
}

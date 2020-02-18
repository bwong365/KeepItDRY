using KeepItDRY.DAL.Entities;

namespace KeepItDRY.DAL.Repositories
{
    public class OwnerRepository : BaseRepository<Owner>, IOwnerRepository
    {
        public OwnerRepository(KeepItDRYContext context) : base(context) { }
    }
}

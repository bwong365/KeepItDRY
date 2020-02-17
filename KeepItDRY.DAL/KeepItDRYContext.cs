using Microsoft.EntityFrameworkCore;

namespace KeepItDRY.DAL
{
    public partial class KeepItDRYContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Pet> Pets { get; set; }

        public KeepItDRYContext(DbContextOptions options) : base(options) { }
    }
}

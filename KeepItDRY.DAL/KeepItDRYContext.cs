using System;
using KeepItDRY.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace KeepItDRY.DAL
{
    public partial class KeepItDRYContext : DbContext
    {
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public KeepItDRYContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Pet>()
                .Property(p => p.PetType)
                .HasConversion(@enum => @enum.ToString(),
                @string => (PetTypes)Enum.Parse(typeof(PetTypes), @string, true));
        }
    }
}

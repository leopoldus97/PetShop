using Microsoft.EntityFrameworkCore;
using PetShop.Core.Entity;

namespace PetShop.Infrastucture.SQLData
{
    public class PetShopContext : DbContext
    {
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pet> Pets { get; set; }

        public PetShopContext(DbContextOptions<PetShopContext> opt) : base(opt)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {

            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<Owner>()

                .HasOne(c => c.Pet)

                .WithMany(ct => ct.PreviousOwner)

                .OnDelete(DeleteBehavior.SetNull);



            modelBuilder.Entity<Pet>()

                .HasMany(u => u.PreviousOwner)

                .WithOne(r => r.Pet)

                .OnDelete(DeleteBehavior.SetNull);



            modelBuilder.Entity<Pet>()

                .HasKey(ol => new { ol.ID });

        }
    }
}

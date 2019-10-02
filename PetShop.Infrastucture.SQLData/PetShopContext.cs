using Microsoft.EntityFrameworkCore;
using PetShop.Core.Entity;

namespace PetShop.Infrastucture.SQLData
{
    public class PetShopContext : DbContext
    {
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<PetColor> PetColors { get; set; }

        public PetShopContext(DbContextOptions<PetShopContext> opt) : base(opt)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {

            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<Pet>()

                .HasMany(p => p.PreviousOwner)

                .WithOne(o => o.Pet)
                
                .OnDelete(DeleteBehavior.SetNull);




            modelBuilder.Entity<Owner>()

                .HasOne(o => o.Pet)

                .WithMany(p => p.PreviousOwner)

                .OnDelete(DeleteBehavior.SetNull);




            modelBuilder.Entity<PetColor>()

            .HasKey(pc => new { pc.PetId, pc.ColorId });



            modelBuilder.Entity<PetColor>()

            .HasOne(pc => pc.Pet)

            .WithMany(p => p.PetColor)
            
            .HasForeignKey(pc => pc.PetId)
            
            .OnDelete(DeleteBehavior.SetNull);



            modelBuilder.Entity<PetColor>()

            .HasOne(pc => pc.Color)

            .WithMany(c => c.PetColor)

            .HasForeignKey(pc => pc.ColorId)

            .OnDelete(DeleteBehavior.SetNull);

        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace PetHubApi.Data
{
    public class PetAPIDBContext:DbContext
    {
        public PetAPIDBContext(DbContextOptions options): base(options)
        {
            
        }

        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Pet> Pets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id = 1,
                    Name = "Nigeria",
                    ShortName="NG"
               });

            modelBuilder.Entity<Breed>().HasData
                (
                new Breed
                {
                    Id = 1,
                    Name = "rot",
                    Description = "Rot has a big head",
                    CountryId = 1,
                }
                );
        }

    }

   

}

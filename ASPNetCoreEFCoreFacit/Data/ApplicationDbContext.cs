using Microsoft.EntityFrameworkCore;

namespace ASPNetCoreEFCoreFacit.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        :base(options)
        {
            
        }

        public DbSet<Bil> Bilar { get; set; }
        public DbSet<Lastbil> Lastbilar { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<UserRegistration> UserRegistrations { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<CV> CVs { get; set; }
        public DbSet<Utbildning> Utbildningar { get; set; }
    }
}
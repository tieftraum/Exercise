using Exercise.Database.EntityConfigurations;
using Exercise.Domain.Records;
using Microsoft.EntityFrameworkCore;

namespace Exercise.Database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PhoneConfiguration());
            modelBuilder.ApplyConfiguration(new ManufacturerConfiguration());
        }
    }
}
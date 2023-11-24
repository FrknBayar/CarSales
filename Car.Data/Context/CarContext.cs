using Car.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Car.Data.Context
{
    public class CarContext : DbContext
    {
        public CarContext()
        {

        }

        public CarContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<CarSales>(entity =>
            {
                entity.HasKey(e => e.Id);
            });
        }
        public DbSet<CarSales> CarSales { get; set; }

    }
}

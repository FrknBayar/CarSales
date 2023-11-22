using Entities.Entity;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Context
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
            optionsBuilder.UseSqlServer("Server=DESKTOP-MJTOPVQ\\SQLEXPRESS;Database=Cars;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<CarSales>(entity =>
            {
                entity.HasKey(e => e.SerialNumber);
            });
        }
        public DbSet<CarSales> Cars { get; set; }

    }
}

using Microsoft.EntityFrameworkCore;
using SupCommerce.Data.EntityConfigurations;

namespace SupCommerce.Data.Data
{
    public class SupCommerceDbContext : DbContext
    {
        public SupCommerceDbContext(DbContextOptions options)
        :base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        }
    }
}
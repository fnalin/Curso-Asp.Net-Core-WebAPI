using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FN.Store.Data.EF
{
    public class StoreDataContext: DbContext
    {
        private readonly IConfiguration _config;

        public StoreDataContext(IConfiguration config)
        {
            _config = config;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("StoreConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Maps.ProdutoMap());
            modelBuilder.ApplyConfiguration(new Maps.CategoriaMap());

            modelBuilder.Seed();
        }

    }
}

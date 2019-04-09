using FN.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FN.Store.Data.EF
{
    public class StoreDataContext: DbContext
    {

        public StoreDataContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=storedb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>()
                   .ToTable(nameof(Produto)).HasKey(p => p.Id);

            modelBuilder.Entity<Produto>()
                    .HasData(
                        new Produto() { Id = 1, Nome = "Picanha", Categoria = "Alimento", Preco = 99.9M },
                        new Produto() { Id = 2, Nome = "Pasta de Dente", Categoria = "Higiene", Preco = 9.9M },
                        new Produto() { Id = 3, Nome = "Danone", Categoria = "Alimento", Preco = 10.59M },
                        new Produto() { Id = 4, Nome = "Caneta Bic", Categoria = "Papelaria", Preco = 1.9M },
                        new Produto() { Id = 5, Nome = "Caderno 10 Matérias", Categoria = "Papelaria", Preco = 55.4M },
                        new Produto() { Id = 6, Nome = "Fralda Pampers", Categoria = "Higiene", Preco = 50.1M }
                    );

           
                 
        }

    }
}

using DotLanches.Domain.Entities;
using DotLanches.Infra.ModelConfiguration;
using Microsoft.EntityFrameworkCore;

namespace DotLanches.Infra.Data
{
    internal class DotLanchesDbContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        public DotLanchesDbContext(DbContextOptions<DotLanchesDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new CategoriaModelConfiguration().Configure(modelBuilder.Entity<Categoria>());
            new ProdutoModelConfiguration().Configure(modelBuilder.Entity<Produto>());
        }
    }
}
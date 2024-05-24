using DotLanches.Domain.Entities;
using DotLanches.Infra.ModelConfiguration;
using Microsoft.EntityFrameworkCore;

namespace DotLanches.Infra.Data
{
    internal class DotLanchesDbContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Combo> Combos { get; set; }
        public DbSet<Status> Status { get; set; }

        public DotLanchesDbContext(DbContextOptions<DotLanchesDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new CategoriaModelConfiguration().Configure(modelBuilder.Entity<Categoria>());
            new ProdutoModelConfiguration().Configure(modelBuilder.Entity<Produto>());
            new ClienteModelConfiguration().Configure(modelBuilder.Entity<Cliente>());
            new PedidoModelConfiguration().Configure(modelBuilder.Entity<Pedido>());
            new ComboModelConfiguration().Configure(modelBuilder.Entity<Combo>());
            new StatusModelConfiguration().Configure(modelBuilder.Entity<Status>());
        }
    }
}
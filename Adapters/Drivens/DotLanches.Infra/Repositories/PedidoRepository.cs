#pragma warning disable CS8602 // Desreferência de uma referência possivelmente nula.
using DotLanches.Domain.Entities;
using DotLanches.Domain.Interfaces.Repositories;
using DotLanches.Infra.Data;
using DotLanches.Infra.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace DotLanches.Infra.Repositories
{
    internal class PedidoRepository : IPedidoRepository
    {
        private readonly DotLanchesDbContext _dbContext;

        public PedidoRepository(DotLanchesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Pedido pedido)
        {
            if (pedido.ClienteCpf is not null)
            {
                var clienteCpf = await _dbContext.Clientes.FirstOrDefaultAsync(c => c.Cpf == pedido.ClienteCpf) ??
                    throw new EntityNotFoundException("Cliente not found!");
                pedido.ClienteCpf = clienteCpf.Cpf;
            }

            _dbContext.Pedidos.Add(pedido);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Pedido>> GetAll()
        {
            var pedidos = await _dbContext.Pedidos
                .Include(p => p.Combos)
                    .ThenInclude(c => c.Lanche)
                        .ThenInclude(l => l.Categoria)
                .Include(p => p.Combos)
                    .ThenInclude(c => c.Acompanhamento)
                        .ThenInclude(a => a.Categoria)
                .Include(p => p.Combos)
                    .ThenInclude(c => c.Bebida)
                        .ThenInclude(b => b.Categoria)
                .Include(p => p.Combos)
                    .ThenInclude(c => c.Sobremesa)
                        .ThenInclude(s => s.Categoria)
                .Where(p => p.StatusId !=  (int)StatusPedido.Finalizado)
                .OrderBy(p => p.CreatedAt)
                .ToListAsync();

            foreach (var pedido in pedidos)
            {
                foreach (var combo in pedido.Combos)
                {
                    combo.CalculatePrice();
                }
                pedido.CalculateTotalPrice();
            }

            return pedidos;
        }
    }
}

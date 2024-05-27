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
            _dbContext.Entry(pedido.Status).State = EntityState.Unchanged;
            if (pedido.Status is not null)
            {
                var status = await _dbContext.Status.FindAsync(pedido.Status.Id) ??
                    throw new EntityNotFoundException("Status not found!");
                pedido.Status = status;
            }

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
                .Include(p => p.Status)
                .Where(p => p.Status.Id != Status.Finalizado().Id)
                .Where(p => p.Status.Id != 4)
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

        public async Task<int> AssignKey(int idPedido)
        {
            var entity = _dbContext.Pedidos.Find(idPedido) ?? throw new EntityNotFoundException();
            var maxActiveOrderKey = await _dbContext.Pedidos.Where(p => p.Status.Id != 4).MaxAsync(p => (int?)p.QueueKey) ?? 0;
            entity.QueueKey = maxActiveOrderKey + 1;
            entity.AddedToQueueAt = DateTime.UtcNow;
            await _dbContext.SaveChangesAsync();
            return entity.QueueKey;
        }

        public async Task<Pedido?> GetById(int id) => await _dbContext.Pedidos
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
                .Include(p => p.Status)
                .FirstOrDefaultAsync();

        public async Task<Pedido> Update(Pedido pedido)
        {
            _dbContext.Update(pedido);
            await _dbContext.SaveChangesAsync();
            return pedido;
        }
    }
}
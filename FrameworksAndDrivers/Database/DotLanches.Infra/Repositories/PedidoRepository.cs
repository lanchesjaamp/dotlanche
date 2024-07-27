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
                var clienteCpf = await _dbContext.Clientes.FirstOrDefaultAsync(c => c.Cpf.Number == pedido.ClienteCpf) ??
                    throw new EntityNotFoundException("Cliente not found!");
                pedido.ClienteCpf = clienteCpf.Cpf.Number;
            }

            _dbContext.Pedidos.Add(pedido);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Pedido>> GetPedidosQueue()
        {
            var queueStatusIds = new[] { Status.Pronto().Id, Status.EmPreparacao().Id, Status.Recebido().Id };

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
                    .Where(p => queueStatusIds.Contains(p.Status.Id))
                .OrderByDescending(p => p.Status.Id)
                .ThenBy(p => p.CreatedAt)
                .ToListAsync();

            return pedidos;
        }

        public async Task<int> GetLastQueueKeyNumber()
        {
            var lastQueueKeyNumber = await _dbContext.Pedidos
                .MaxAsync(p => p.QueueKey);

            return lastQueueKeyNumber;
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
                .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Pedido> Update(Pedido pedido)
        {
            _dbContext.Update(pedido);
            await _dbContext.SaveChangesAsync();
            _dbContext.ChangeTracker.Clear();
            return pedido;
        }

        public async Task<Pedido> UpdateStatus(Pedido pedido)
        {
            _dbContext.Update(pedido);
            await _dbContext.SaveChangesAsync();
            return pedido;
        }
    }
}
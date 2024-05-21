using DotLanches.Domain.Entities;
using DotLanches.Domain.Interfaces.Repositories;
using DotLanches.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            _dbContext.Pedidos.Add(pedido);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Pedido>> GetAll()
        {
            var pedidos = await _dbContext.Pedidos
                .Include(p => p.Combos)
                    .ThenInclude(c => c.Lanche)
                .Include(p => p.Combos)
                    .ThenInclude(c => c.Acompanhamento)
                .Include(p => p.Combos)
                    .ThenInclude(c => c.Bebida)
                .Include(p => p.Combos)
                    .ThenInclude(c => c.Sobremesa)
                .Include(p => p.Cliente)
                .OrderBy(p => p.CreatedAt)
                .Select(pedido => new Pedido
                {
                    Id = pedido.Id,
                    CreatedAt = pedido.CreatedAt,
                    ClienteCPF = pedido.Cliente.Cpf,
                    TotalPrice = pedido.TotalPrice,
                    Combos = pedido.Combos.Select(c => new Combo
                    {
                        Id = c.Id,
                        PedidoId = c.PedidoId,
                        LancheId = c.LancheId,
                        LancheName = _dbContext.Produtos.Where(p => p.Id == c.LancheId).Select(p => p.Name).FirstOrDefault(),
                        AcompanhamentoId = c.AcompanhamentoId,
                        AcompanhamentoName = _dbContext.Produtos.Where(p => p.Id == c.AcompanhamentoId).Select(p => p.Name).FirstOrDefault(),
                        BebidaId = c.BebidaId,
                        BebidaName = _dbContext.Produtos.Where(p => p.Id == c.BebidaId).Select(p => p.Name).FirstOrDefault(),
                        SobremesaId = c.SobremesaId,
                        SobremesaName = _dbContext.Produtos.Where(p => p.Id == c.SobremesaId).Select(p => p.Name).FirstOrDefault(),
                        Price = c.Price
                    }).ToList()
                }).ToListAsync();

                return pedidos;
        }
    }
}

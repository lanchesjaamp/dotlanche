using DotLanches.Domain.Entities;
using DotLanches.Domain.Interfaces.Repositories;
using DotLanches.Infra.Data;
using DotLanches.Infra.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace DotLanches.Infra.Repositories
{
    internal class pagamentoRepository : IPagamentoRepository
    {
        private readonly DotLanchesDbContext _dbContext;

        public ProdutoRepository(DotLanchesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Pagamento pagamento)
        {
            _dbContext.Pagamento.Add(pagamento);

            await _dbContext.SaveChangesAsync();
        }

        public async Task Confirm(int pagamentoId)
        {
            var entity = _dbContext.Pagamento.Find(pagamentoId) ??
                throw new EntityNotFoundException();

            entity.isValid = true;
            entity.HorarioRegistro = DateTime.Now;

            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
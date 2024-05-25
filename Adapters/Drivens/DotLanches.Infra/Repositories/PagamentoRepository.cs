using DotLanches.Domain.Entities;
using DotLanches.Domain.Interfaces.Repositories;
using DotLanches.Infra.Data;
using DotLanches.Infra.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace DotLanches.Infra.Repositories
{
    internal class PagamentoRepository : IPagamentoRepository
    {
        private readonly DotLanchesDbContext _dbContext;

        public PagamentoRepository(DotLanchesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Pagamento pagamento)
        {
            _dbContext.Pagamentos.Add(pagamento);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<Pagamento> Confirm(int pagamentoId)
        {
            var entity = _dbContext.Pagamentos.Find(pagamentoId) ??
                throw new EntityNotFoundException();

            entity.ConfirmPayment();

            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
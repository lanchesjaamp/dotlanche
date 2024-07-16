using DotLanches.Domain.Entities;
using DotLanches.Domain.Interfaces.Repositories;
using DotLanches.Infra.Data;

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

        public async Task<Pagamento> Update(Pagamento pagamento)
        {
            _dbContext.Pagamentos.Update(pagamento);
            await _dbContext.SaveChangesAsync();
            return pagamento;
        }
    }
}
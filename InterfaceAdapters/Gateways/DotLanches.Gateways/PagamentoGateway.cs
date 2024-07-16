using DotLanches.Domain.Entities;
using DotLanches.Domain.Interfaces.Gateways;
using DotLanches.Domain.Interfaces.Repositories;

namespace DotLanches.Gateways
{
    public class PagamentoGateway : IPagamentoGateway
    {
        private readonly IPagamentoRepository _pagamentoRepository;

        public PagamentoGateway(IPagamentoRepository pagamentoRepository)
        {
            _pagamentoRepository = pagamentoRepository;
        }

        public async Task Add(Pagamento pagamento) => await _pagamentoRepository.Add(pagamento);

        public async Task<Pagamento> Update(Pagamento pagamento) => await _pagamentoRepository.Update(pagamento);
    }
}

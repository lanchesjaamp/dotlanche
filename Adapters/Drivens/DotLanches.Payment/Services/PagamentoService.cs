using DotLanches.Application.Services;
using DotLanches.Domain.Entities;
using DotLanches.Domain.Interfaces.Repositories;

namespace DotLanches.Payment.Services
{
    public class PagamentoService : IPagamentoService
    {
        private readonly IPagamentoRepository _repository;

        public PagamentoService(IPagamentoRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<Pagamento> Checkout(Pedido pedido)
        {
            var pagamento = new Pagamento(pedido.Id);
            await _repository.Add(pagamento);
            //Fake Checkout for current version
            pagamento = await _repository.Confirm(pagamento.Id);
            return pagamento;
        }
    }
}
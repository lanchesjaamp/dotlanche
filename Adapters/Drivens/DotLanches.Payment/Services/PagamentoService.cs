using Core.DotLanches.Application;

namespace DotLanches.Payment.Services
{
    internal class PagamentoService : IPagamentoService
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
            await _repository.Confirm(pagamento)
        }
    }
}
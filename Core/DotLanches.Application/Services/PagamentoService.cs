using DotLanches.Domain.Entities;
using DotLanches.Domain.Interfaces.Repositories;
using DotLanches.Domain.Ports;

namespace DotLanches.Application.Services
{
    public class PagamentoService : IPagamentoService
    {
        private readonly IPagamentoRepository _repository;
        private readonly ICheckout _checkout;
        private readonly IPedidoRepository _pedidoRepository;

        public PagamentoService(IPagamentoRepository repository, ICheckout checkout, IPedidoRepository pedidoRepository)
        {
            _repository = repository;
            _checkout = checkout;
            _pedidoRepository = pedidoRepository;
        }

        public async Task<Pagamento> ProcessPagamento(int idPedido)
        {
            var pedido = await _pedidoRepository.GetById(idPedido) ??
                throw new Exception("Payment processing error: Non existing pedido!");

            var pagamento = new Pagamento(pedido.Id);
            await _repository.Add(pagamento);

            //Fake Checkout for current version
            var paymentSucceded = _checkout.ProcessPayment(pagamento);

            if (paymentSucceded)
            {
                pagamento.ConfirmPayment();
                pedido.ReceivePagamento();

                await _pedidoRepository.Update(pedido);
                pagamento = await _repository.Update(pagamento);
            }

            return pagamento;
        }
    }
}

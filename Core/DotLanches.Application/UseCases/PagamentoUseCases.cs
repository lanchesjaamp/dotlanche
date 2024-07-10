using DotLanches.Domain.Entities;
using DotLanches.Domain.Interfaces.Repositories;
using DotLanches.Domain.Ports;

namespace DotLanches.Application.UseCases
{
    public static class PagamentoUseCases
    {
        public static async Task<Pagamento> ProcessPagamento(int idPedido, IPedidoRepository pedidoRepository, IPagamentoRepository pagamentoRepository, ICheckout checkout)
        {
            var pedido = await pedidoRepository.GetById(idPedido) ??
                throw new Exception("Payment processing error: Non existing pedido!");

            var pagamento = new Pagamento(pedido.Id);
            await pagamentoRepository.Add(pagamento);

            //Fake Checkout for current version
            var paymentSucceded = checkout.ProcessPayment(pagamento);

            if (paymentSucceded)
            {
                pagamento.ConfirmPayment();
                pedido.ReceivePagamento();

                await pedidoRepository.Update(pedido);
                pagamento = await pagamentoRepository.Update(pagamento);
            }

            return pagamento;
        }
    }
}

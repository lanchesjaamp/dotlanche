using DotLanches.Domain.Entities;
using DotLanches.Domain.Interfaces.ExternalInterfaces;
using DotLanches.Domain.Interfaces.Gateways;

namespace DotLanches.Application.UseCases
{
    public static class PagamentoUseCases
    {
        public static async Task<Pagamento> ProcessPagamento(int idPedido, IPedidoGateway pedidoGateway, IPagamentoGateway pagamentoGateway, ICheckout checkout)
        {
            var pedido = await pedidoGateway.GetById(idPedido) ??
                throw new Exception("Payment processing error: Non existing pedido!");

            var pagamento = new Pagamento(pedido.Id);
            await pagamentoGateway.Add(pagamento);

            //Fake Checkout for current version
            var paymentSucceded = checkout.ProcessPayment(pagamento);

            if (paymentSucceded)
            {
                pagamento.ConfirmPayment();
                pedido.ReceivePagamento();

                await pedidoGateway.Update(pedido);
                pagamento = await pagamentoGateway.Update(pagamento);
            }

            return pagamento;
        }
    }
}

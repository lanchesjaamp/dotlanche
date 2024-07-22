using DotLanches.Domain.Entities;
using DotLanches.Domain.Interfaces.ExternalInterfaces;
using DotLanches.Domain.Interfaces.Gateways;

namespace DotLanches.Application.UseCases
{
    public static class PagamentoUseCases
    {
        public static async Task<string> ProcessPagamento(int idPedido, IPedidoGateway pedidoGateway, IPagamentoGateway pagamentoGateway, ICheckout checkout)
        {
            var pedido = await pedidoGateway.GetById(idPedido) ??
                throw new Exception("Payment processing error: Non existing pedido!");

            var pagamento = new Pagamento(pedido.Id);
            await pagamentoGateway.Add(pagamento);

            //Fake Checkout for current version
            var qrCode = checkout.ProcessPayment(pagamento);

            return qrCode;
        }

        public static async Task<Pagamento> AcceptedPagamento(int idPedido, IPedidoGateway pedidoGateway, IPagamentoGateway pagamentoGateway)
        {
            var pedido = await pedidoGateway.GetById(idPedido) ??
                throw new Exception("Payment processing error: Non existing pedido!");

            var pagamento = new Pagamento(pedido.Id);

            await pagamentoGateway.Add(pagamento);

            pagamento.ConfirmPayment();

            pedido.ReceivePagamento();

            await pedidoGateway.Update(pedido);

            pagamento = await pagamentoGateway.Update(pagamento);

            return pagamento;
        }

        public static async Task<Pagamento> RefusedPagamento(int idPedido, IPedidoGateway pedidoGateway, IPagamentoGateway pagamentoGateway)
        {
            var pedido = await pedidoGateway.GetById(idPedido) ??
                throw new Exception("Payment processing error: Non existing pedido!");

            var pagamento = new Pagamento(pedido.Id);

            await pagamentoGateway.Add(pagamento);

            pagamento.RefusePayment();

            pagamento = await pagamentoGateway.Update(pagamento);

            return pagamento;
        }
    }
}

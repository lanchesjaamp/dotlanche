using DotLanches.Domain.Entities;
using DotLanches.Domain.Interfaces.ExternalInterfaces;
using DotLanches.Domain.Interfaces.Gateways;

namespace DotLanches.Application.UseCases
{
    public static class PagamentoUseCases
    {
        public static async Task<string> RequestQrCodeForPedido(int idPedido, IPedidoGateway pedidoGateway, IPagamentoGateway pagamentoGateway, ICheckout checkout)
        {
            var pedido = await pedidoGateway.GetById(idPedido) ??
                throw new Exception("Payment processing error: Non existing pedido!");

            if (pedido.Status.Id != Status.Confirmado().Id) throw new Exception("Payment processing error: Pedido not confirmed!");

            var pagamento = new Pagamento(pedido.Id);
            await pagamentoGateway.Add(pagamento);

            //Fake Checkout for current version
            var qrCode = checkout.RequestQrCode(pagamento);

            return qrCode;
        }

        public static async Task<QueueKey> AcceptedPagamento(int idPedido, IPedidoGateway pedidoGateway, IPagamentoGateway pagamentoGateway)
        {
            var pedido = await pedidoGateway.GetById(idPedido) ??
                throw new Exception("Payment processing error: Non existing pedido!");

            if (pedido.Status.Id != Status.Confirmado().Id)
                throw new Exception("Payment processing error: Pedido not confirmed!");

            var pagamento = await pagamentoGateway.GetByIdPedido(pedido.Id);
            pagamento.ConfirmPayment();

            var lastQueueKey = await pedidoGateway.GetLastQueueKeyNumber();
            var newQueueKey = new QueueKey(lastQueueKey + 1, pagamento.RegisteredAt!.Value);

            pedido.ReceivePagamento(newQueueKey);

            await pagamentoGateway.Update(pagamento);
            await pedidoGateway.Update(pedido);

            return newQueueKey;
        }

        public static async Task<Pagamento> RefusedPagamento(int idPedido, IPedidoGateway pedidoGateway, IPagamentoGateway pagamentoGateway)
        {
            var pedido = await pedidoGateway.GetById(idPedido) ??
                throw new Exception("Payment processing error: Non existing pedido!");

            if (pedido.Status.Id != Status.Confirmado().Id)
                throw new Exception("Payment processing error: Pedido not confirmed!");

            var pagamento = await pagamentoGateway.GetByIdPedido(pedido.Id);
            pagamento.RefusePayment();

            pagamento = await pagamentoGateway.Update(pagamento);
            return pagamento;
        }

        public static async Task<Pagamento> GetByIdPedido(int idPedido, IPagamentoGateway pagamentoGateway)
        {
            return await pagamentoGateway.GetByIdPedido(idPedido);
        }
    }
}
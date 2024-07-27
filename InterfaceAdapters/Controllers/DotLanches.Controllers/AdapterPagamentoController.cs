using DotLanches.Application.UseCases;
using DotLanches.Domain.Interfaces.ExternalInterfaces;
using DotLanches.Domain.Interfaces.Repositories;
using DotLanches.Gateways;
using DotLanches.Presenters.Dtos;
using DotLanches.Presenters.Mappers;

namespace DotLanches.Controllers
{
    public class AdapterPagamentoController
    {
        private readonly IPagamentoRepository _pagamentoRepository;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly ICheckout _checkout;

        public AdapterPagamentoController(IPagamentoRepository pagamentoRepository, IPedidoRepository pedidoRepository, ICheckout checkout)
        {
            _pagamentoRepository = pagamentoRepository;
            _pedidoRepository = pedidoRepository;
            _checkout = checkout;
        }

        public async Task<string> RequestPagamentoQRCode(int idPedido)
        {
            var pedidoGateway = new PedidoGateway(_pedidoRepository);
            var pagamentoGateway = new PagamentoGateway(_pagamentoRepository);
            var qrCode = await PagamentoUseCases.RequestQrCodeForPedido(idPedido, pedidoGateway, pagamentoGateway, _checkout);

            return qrCode;
        }

        public async Task<PagamentoViewModel?> ProcessPagamento(int idPedido, bool isAccepted)
        {
            var pedidoGateway = new PedidoGateway(_pedidoRepository);
            var pagamentoGateway = new PagamentoGateway(_pagamentoRepository);

            if (isAccepted)
            {
                var queueKey = await PagamentoUseCases.AcceptedPagamento(idPedido, pedidoGateway, pagamentoGateway);
                return PagamentoPresenter.GetPagamentoViewModel(isAccepted: true, queueKey.CreationDate, queueKey.Value);
            }
            else
            {
                await PagamentoUseCases.RefusedPagamento(idPedido, pedidoGateway, pagamentoGateway);
                return PagamentoPresenter.GetPagamentoViewModel(isAccepted: false, DateTime.Now);
            }
        }

        public async Task<PagamentoViewModel?> GetByIdPedido(int idPedido)
        {
            var pagamentoGateway = new PagamentoGateway(_pagamentoRepository);
            var pagamento = await pagamentoGateway.GetByIdPedido(idPedido);

            return PagamentoPresenter.GetPagamentoViewModel(pagamento.IsAccepted, pagamento.RegisteredAt);
        }
    }
}
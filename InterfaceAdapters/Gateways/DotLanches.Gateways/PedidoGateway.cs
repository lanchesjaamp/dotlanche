using DotLanches.Domain.Entities;
using DotLanches.Domain.Interfaces.Gateways;
using DotLanches.Domain.Interfaces.Repositories;

namespace DotLanches.Gateways
{
    public class PedidoGateway : IPedidoGateway
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoGateway(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task Add(Pedido pedido) => await _pedidoRepository.Add(pedido);

        public async Task<int> AssignKey(int idPedido) => await _pedidoRepository.AssignKey(idPedido);

        public async Task<IEnumerable<Pedido>> GetPedidosQueue() => await _pedidoRepository.GetPedidosQueue();

        public async Task<Pedido?> GetById(int id) => await _pedidoRepository.GetById(id);

        public async Task<Pedido> Update(Pedido pedido) => await _pedidoRepository.Update(pedido);

        public async Task<Pedido> UpdateStatus(Pedido pedido) => await _pedidoRepository.UpdateStatus(pedido);
    }
}

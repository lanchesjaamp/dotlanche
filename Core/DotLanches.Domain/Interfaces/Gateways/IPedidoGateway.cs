using DotLanches.Domain.Entities;

namespace DotLanches.Domain.Interfaces.Gateways
{
    public interface IPedidoGateway
    {
        Task Add(Pedido pedido);

        Task<Pedido> Update(Pedido pedido);

        Task<int> GetLastQueueKeyNumber(int idPedido);

        Task<IEnumerable<Pedido>> GetPedidosQueue();

        Task<Pedido?> GetById(int id);

        Task<Pedido> UpdateStatus(Pedido pedido);
    }
}

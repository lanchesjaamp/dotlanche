using DotLanches.Domain.Entities;

namespace DotLanches.Domain.Interfaces.Repositories
{
    public interface IPedidoRepository
    {
        Task Add(Pedido pedido);

        Task<Pedido> Update(Pedido pedido);

        Task<int> GetLastQueueKeyNumber();

        Task<IEnumerable<Pedido>> GetPedidosQueue();

        Task<Pedido?> GetById(int id);

        Task<Pedido> UpdateStatus(Pedido pedido);
    }
}

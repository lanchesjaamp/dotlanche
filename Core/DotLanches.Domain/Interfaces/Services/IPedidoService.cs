using DotLanches.Domain.Entities;

namespace DotLanches.Domain.Interfaces.Services
{
    public interface IPedidoService
    {
        Task Add(Pedido pedido);

        Task<IEnumerable<Pedido>> GetAll();

        Task<int> QueueKeyAssignment(int idPedido);
    }
}

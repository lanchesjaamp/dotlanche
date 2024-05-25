using DotLanches.Domain.Entities;

namespace DotLanches.Domain.Interfaces.Repositories
{
  public interface IPagamentoRepository
  {
    Task<Pedido> Add(Pedido pedido);

    Task<Pedido> Confirm(Pedido pedido);
  }
}
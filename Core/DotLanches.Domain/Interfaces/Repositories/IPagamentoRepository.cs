using DotLanches.Domain.Entities;

namespace DotLanches.Domain.Interfaces.Repositories
{
  public interface IPagamentoRepository
  {
    Task Add(Pagamento pagamento);

    Task<Pagamento> Update(Pagamento pagamento);

    Task<Pagamento> GetByIdPedido(int idPedido);
  }
}
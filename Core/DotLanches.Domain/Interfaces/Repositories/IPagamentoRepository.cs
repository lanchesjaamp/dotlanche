using DotLanches.Domain.Entities;

namespace DotLanches.Domain.Interfaces.Repositories
{
  public interface IPagamentoRepository
  {
    Task Add(Pagamento pagamento);

    Task<Pagamento> Confirm(int idPagamento);
  }
}
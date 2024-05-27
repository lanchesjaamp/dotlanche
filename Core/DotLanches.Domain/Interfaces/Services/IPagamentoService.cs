using DotLanches.Domain.Entities;

namespace DotLanches.Application.Services
{
    public interface IPagamentoService
    {
        Task<Pagamento> ProcessPagamento(int idPedido);
    }
}
using DotLanches.Domain.Entities;

namespace DotLanches.Application.Services
{
    public interface IPagamentoService
    {
        Task<Pagamento> Checkout(Pedido pedido);
    }
}
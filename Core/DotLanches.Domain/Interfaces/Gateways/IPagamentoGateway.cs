using DotLanches.Domain.Entities;

namespace DotLanches.Domain.Interfaces.Gateways
{
    public interface IPagamentoGateway
    {
        Task Add(Pagamento pagamento);

        Task<Pagamento> GetByIdPedido(int idPedido);

        Task<Pagamento> Update(Pagamento pagamento);
    }
}

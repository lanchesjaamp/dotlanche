using DotLanches.Domain.Entities;

namespace DotLanches.Domain.Interfaces.Gateways
{
    public interface IPagamentoGateway
    {
        Task Add(Pagamento pagamento);

        Task<Pagamento> Update(Pagamento pagamento);
    }
}

using DotLanches.Domain.Entities;

namespace DotLanches.Domain.Interfaces.ExternalInterfaces
{
    public interface ICheckout
    {
        bool ProcessPayment(Pagamento pagamento);
    }
}

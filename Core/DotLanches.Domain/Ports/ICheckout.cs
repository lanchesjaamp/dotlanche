using DotLanches.Domain.Entities;

namespace DotLanches.Domain.Ports
{
    public interface ICheckout
    {
        bool ProcessPayment(Pagamento pagamento);
    }
}

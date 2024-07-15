using DotLanches.Domain.Entities;
using DotLanches.Domain.Interfaces.ExternalInterfaces;

namespace DotLanches.Payment.FakeCheckout
{
    public class FakeCheckout : ICheckout
    {
        public bool ProcessPayment(Pagamento pagamento)
        {
            return true;
        }
    }
}

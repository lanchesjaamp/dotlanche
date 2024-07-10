using DotLanches.Domain.Entities;
using DotLanches.Domain.Ports;

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

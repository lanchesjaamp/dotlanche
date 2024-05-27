using DotLanches.Domain.Entities;
using DotLanches.Domain.Ports;

namespace DotLanches.Payment
{
    public class FakeCheckout : ICheckout
    {
        public bool ProcessPayment(Pagamento pagamento)
        {
            return true;
        }
    }
}
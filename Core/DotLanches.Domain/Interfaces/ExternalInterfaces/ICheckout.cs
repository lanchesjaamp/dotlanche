using DotLanches.Domain.Entities;

namespace DotLanches.Domain.Interfaces.ExternalInterfaces
{
    public interface ICheckout
    {
        string RequestQrCode(Pagamento pagamento);
    }
}

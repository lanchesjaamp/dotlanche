namespace DotLanches.Domain.Entities;

public class Pagamento
{
    public int Id { get; private set; }

    public int? IdPedido { get; set; }

    public bool? IsAccepted { get; set; }
    
    public DateTime? RegisteredAt { get; set; }

    private Pagamento() {}

    public Pagamento(int? idPedido)
    {
        IdPedido = idPedido ?? throw new ArgumentNullException(nameof(idPedido));
    }

    public void ConfirmPayment()
    {
        this.IsAccepted = true;
        this.RegisteredAt = DateTime.Now;
    }
}
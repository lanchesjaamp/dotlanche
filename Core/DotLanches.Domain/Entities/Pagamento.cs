namespace DotLanches.Domain.Entities;

public class Pagamento
{
    public int Id { get; private set; }

    public int? IdPedido { get; set; }

    public bool? IsAccepted { get; set; }
    
    public DateTime? HorarioRegistro { get; set; }

    private Pagamento() {}

    public Pagamento(int idPedido)
    {
        this.IdPedido = idPedido ?? throw new ArgumentNullException(nameof(idPedido));
    }

    public void ConfirmPayment()
    {
        this.IsAccepted = true;
        this.HorarioRegistro = DateTime.Now;
    }
}
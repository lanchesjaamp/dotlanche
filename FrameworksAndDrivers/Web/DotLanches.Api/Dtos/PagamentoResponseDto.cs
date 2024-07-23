namespace DotLanches.Api.Dtos;

public class ProcessPagamentoRequestDto
{
    public int IdPedido { get; set; }

    public bool PaymentStatus { get; set; }
}

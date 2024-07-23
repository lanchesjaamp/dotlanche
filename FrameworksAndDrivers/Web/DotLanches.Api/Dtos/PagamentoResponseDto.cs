namespace DotLanches.Api.Dtos;

public class ProcessPagamentoRequestDto
{
    public int IdPedido { get; set; }

    public bool IsAccepted { get; set; }
}

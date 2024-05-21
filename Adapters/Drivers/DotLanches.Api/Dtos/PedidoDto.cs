namespace DotLanches.Api.Dtos
{
    public class PedidoDto
    {
        public string? ClienteCPF { get; set; }
        public List<ComboDto> Combos { get; set; }
    }
}

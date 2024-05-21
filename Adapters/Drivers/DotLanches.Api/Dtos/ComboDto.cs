namespace DotLanches.Api.Dtos
{
    public class ComboDto
    {
        public int? LancheId { get; set; }
        public int? AcompanhamentoId { get; set; }
        public int? BebidaId { get; set; }
        public int? SobremesaId { get; set; }
        public decimal Price { get; set; }
    }
}

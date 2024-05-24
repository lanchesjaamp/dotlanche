#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace DotLanches.Api.Dtos
{
    public class ComboDto
    {
        public int? LancheId { get; set; }
        public int? AcompanhamentoId { get; set; }
        public int? BebidaId { get; set; }
        public int? SobremesaId { get; set; }
    }
}

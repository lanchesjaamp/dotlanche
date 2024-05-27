#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
using System.ComponentModel.DataAnnotations;
using DotLanches.Domain.ValueObjects;

namespace DotLanches.Api.Dtos
{
    public class PedidoDto
    {
        public Cpf? ClienteCpf { get; set; }
        [Required]
        public IEnumerable<ComboDto> Combos { get; set; }
    }
}
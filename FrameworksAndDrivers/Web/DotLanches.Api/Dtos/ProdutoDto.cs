#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
using System.ComponentModel.DataAnnotations;

namespace DotLanches.Api.Dtos
{
    public class ProdutoDto
    {
        public enum CategoriaEnum
        {
            Lanche = 1,
            Acompanhamento = 2,
            Bebida = 3,
            Sobremesa = 4,
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public CategoriaEnum CategoriaId { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
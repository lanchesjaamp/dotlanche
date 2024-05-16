using DotLanches.Api.Dtos;
using DotLanches.Domain.Entities;

namespace DotLanches.Api.Mappers
{
    public static class ProdutoMapper
    {
        public static Produto ToDomainModel(this ProdutoDto produtoDto)
        {
            var domainModel = new Produto()
            {
                Id = produtoDto.Id,
                Categoria = new Categoria() { Id = produtoDto.CategoriaId },
                Description = produtoDto.Description,
                Name = produtoDto.Nome,
                Price = produtoDto.Price,
            };

            return domainModel;
        }
    }
}
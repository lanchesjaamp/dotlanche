using DotLanches.Api.Dtos;
using DotLanches.Domain.Entities;

namespace DotLanches.Api.Mappers
{
    public static class ProdutoMapper
    {
        public static Produto ToDomainModel(this ProdutoDto produtoDto, int id = 0)
        {
            var domainModel = new Produto(id,
                                          produtoDto.Name,
                                          produtoDto.Description,
                                          produtoDto.Price,
                                          new Categoria() { Id = (int)produtoDto.CategoriaId });

            return domainModel;
        }
    }
}
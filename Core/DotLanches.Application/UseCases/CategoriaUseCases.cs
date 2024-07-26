using DotLanches.Domain.Entities;
using DotLanches.Domain.Exceptions;
using DotLanches.Domain.Interfaces.Gateways;

namespace DotLanches.Application.UseCases
{
    public static class CategoriaUseCases
    {
        public static async Task<IEnumerable<Categoria>> ShowAllCategorias(ICategoriaGateway categoriaGateway) => await categoriaGateway.GetAllCategorias();

        public static async Task<Categoria> ShowSelectedCategoria(int idCategoria, ICategoriaGateway categoriaGateway)
        {
            var categoria = await categoriaGateway.GetCategoriaById(idCategoria);
            return categoria is null ? throw new CategoriaNotFoundException() : categoria;
        }
    }
}

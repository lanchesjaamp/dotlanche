using DotLanches.Domain.Entities;

namespace DotLanches.Application.Services
{
    public interface IProdutoService
    {
        Task Add(Produto produto);

        Task<Produto> Edit(Produto produto);

        Task<Produto> Delete(int idProduto);

        Task<IEnumerable<Produto>> GetByCategoria(int idCategoria);
        Task<Produto> GetById(int idProduto);
    }
}
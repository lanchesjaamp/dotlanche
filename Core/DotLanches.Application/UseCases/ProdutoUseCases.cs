using DotLanches.Domain.Entities;
using DotLanches.Domain.Interfaces.Repositories;

namespace DotLanches.Application.UseCases
{
    public static class ProdutoUseCases
    {
        public static async Task Add(Produto produto, IProdutoRepository repository) => await repository.Add(produto);

        public static async Task<Produto> Edit(Produto produto, IProdutoRepository repository) => await repository.Edit(produto);

        public static async Task<Produto> Delete(int idProduto, IProdutoRepository repository) => await repository.Delete(idProduto);

        public static async Task<IEnumerable<Produto>> GetByCategoria(int idCategoria, IProdutoRepository repository) => await repository.GetByCategoria(idCategoria);

        public static async Task<Produto> GetById(int idProduto, IProdutoRepository repository) => await repository.GetById(idProduto);
    }
}
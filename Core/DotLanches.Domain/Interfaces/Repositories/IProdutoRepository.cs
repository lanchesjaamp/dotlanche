using DotLanches.Domain.Entities;

namespace DotLanches.Domain.Interfaces.Repositories
{
    public interface IProdutoRepository
    {
        public Task Add(Produto produto);

        public Task<Produto> Edit(Produto produto);

        public Task<Produto> Delete(int idProduto);

        public Task<IEnumerable<Produto>> GetByCategoria(int idCategoria);
    }
}
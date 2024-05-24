using DotLanches.Domain.Entities;
using DotLanches.Domain.Interfaces.Repositories;

namespace DotLanches.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repository;

        public ProdutoService(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task Add(Produto produto) => await _repository.Add(produto);

        public async Task<Produto> Edit(Produto produto) => await _repository.Edit(produto);

        public async Task<Produto> Delete(int idProduto) => await _repository.Delete(idProduto);

        public async Task<IEnumerable<Produto>> GetByCategoria(int idCategoria) => await _repository.GetByCategoria(idCategoria);

        public async Task<Produto> GetById(int idProduto) => await _repository.GetById(idProduto);
    }
}
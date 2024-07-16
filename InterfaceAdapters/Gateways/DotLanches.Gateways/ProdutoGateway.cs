using DotLanches.Domain.Entities;
using DotLanches.Domain.Interfaces.Gateways;
using DotLanches.Domain.Interfaces.Repositories;

namespace DotLanches.Gateways
{
    public class ProdutoGateway : IProdutoGateway
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoGateway(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task Add(Produto produto) => await _produtoRepository.Add(produto);

        public async Task<Produto> Delete(int idProduto) => await _produtoRepository.Delete(idProduto);

        public async Task<Produto> Edit(Produto produto) => await _produtoRepository.Edit(produto);

        public async Task<IEnumerable<Produto>> GetByCategoria(int idCategoria) => await _produtoRepository.GetByCategoria(idCategoria);

        public async Task<Produto> GetById(int idProduto) => await _produtoRepository.GetById(idProduto);
    }
}

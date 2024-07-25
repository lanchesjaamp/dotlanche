using DotLanches.Application.UseCases;
using DotLanches.Domain.Entities;
using DotLanches.Domain.Interfaces.Repositories;
using DotLanches.Gateways;
using System.Net.Http.Headers;

namespace DotLanches.Controllers;

public class AdapterProdutoController
{
    private readonly IProdutoRepository _produtoRepository;

    public AdapterProdutoController(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task AddProduto(Produto produto)
    {
        var gateway = new ProdutoGateway(_produtoRepository);
        await ProdutoUseCases.RegisterNewProduto(produto, gateway);
    }

    public async Task<Produto> EditProduto(Produto produto)
    {
        var gateway = new ProdutoGateway(_produtoRepository);
        var prod = await ProdutoUseCases.EditExistingProduto(produto, gateway);
        return prod;
    }

    public async Task<Produto> DeleteProduto(int idProduto)
    {
        var gateway = new ProdutoGateway(_produtoRepository);
        var prod = await ProdutoUseCases.RemoveProduto(idProduto, gateway);
        return prod;
    }

    public async Task<IEnumerable<Produto>> GetByCategoria(int categoriaId)
    {
        var gateway = new ProdutoGateway(_produtoRepository);
        var produtos = await ProdutoUseCases.ShowAllProdutosForGivenCategory(categoriaId, gateway);
        return produtos;
    }

    public async Task<Produto> GetById(int idProduto)
    {
        var gateway = new ProdutoGateway(_produtoRepository);
        var produto = await ProdutoUseCases.ShowSelectedProduto(idProduto, gateway);
        return produto;
    }
}

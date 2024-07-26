using DotLanches.Application.UseCases;
using DotLanches.Domain.Entities;
using DotLanches.Domain.Interfaces.Repositories;
using DotLanches.Gateways;

namespace DotLanches.Controllers;

public class AdapterCategoriaController
{
    private readonly ICategoriaRepository _repository;

    public AdapterCategoriaController(ICategoriaRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Categoria>> GetAllCategorias()
    {
        var gateway = new CategoriaGateway(_repository);
        var categorias = await CategoriaUseCases.ShowAllCategorias(gateway);
        return categorias;
    }

    public async Task<Categoria> GetCategoriaById(int idCategoria)
    {
        var gateway = new CategoriaGateway(_repository);
        var categoria = await CategoriaUseCases.ShowSelectedCategoria(idCategoria, gateway);
        return categoria;
    }
}

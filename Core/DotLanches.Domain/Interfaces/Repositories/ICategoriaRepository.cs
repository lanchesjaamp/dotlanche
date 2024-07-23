using DotLanches.Domain.Entities;

namespace DotLanches.Domain.Interfaces.Repositories;

public interface ICategoriaRepository
{
    public Task<IEnumerable<Categoria>> GetAll();

    public Task<Categoria?> GetById(int idCategoria);
}

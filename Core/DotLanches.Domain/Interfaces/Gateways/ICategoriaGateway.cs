using DotLanches.Domain.Entities;

namespace DotLanches.Domain.Interfaces.Gateways
{
    public interface ICategoriaGateway
    {
        Task<IEnumerable<Categoria>> GetAllCategorias();

        Task<Categoria?> GetCategoriaById(int id);
    }
}

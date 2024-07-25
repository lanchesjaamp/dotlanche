using DotLanches.Domain.Entities;
using DotLanches.Domain.Interfaces.Gateways;
using DotLanches.Domain.Interfaces.Repositories;

namespace DotLanches.Gateways
{
    public class CategoriaGateway : ICategoriaGateway
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaGateway(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Categoria>> GetAllCategorias() => _repository.GetAll();

        public Task<Categoria?> GetCategoriaById(int id) => _repository.GetById(id);
    }
}

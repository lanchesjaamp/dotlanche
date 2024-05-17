using DotLanches.Domain.Entities;
using DotLanches.Domain.Interfaces.Repositories;

namespace DotLanches.Application.Services {
    public class ClienteService : IClienteService {
        private readonly IClienteRepository _repository;

        public ClienteService(IClienteRepository repository) {
            _repository = repository;
        }

        public async Task Add(Cliente cliente) => await _repository.Add(cliente);

        public async Task<Cliente> Edit(Cliente cliente) => await _repository.Edit(cliente);

        public async Task<Cliente> Delete(int idCliente) => await _repository.Delete(idCliente);

        public async Task<IEnumerable<Cliente>> GetAll() => await _repository.GetAll();
    }
}

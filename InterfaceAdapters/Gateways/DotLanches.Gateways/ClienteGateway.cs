using DotLanches.Domain.Entities;
using DotLanches.Domain.Interfaces.Gateways;
using DotLanches.Domain.Interfaces.Repositories;

namespace DotLanches.Gateways
{
    public class ClienteGateway : IClienteGateway
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteGateway(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task Add(Cliente cliente) => await _clienteRepository.Add(cliente);

        public async Task<Cliente> Delete(int idCliente) => await _clienteRepository.Delete(idCliente);

        public async Task<Cliente> Edit(Cliente cliente) => await _clienteRepository.Edit(cliente);

        public Task<IEnumerable<Cliente>> GetAll() => _clienteRepository.GetAll();

        public async Task<Cliente?> GetByCpf(string cpf) => await _clienteRepository.GetByCpf(cpf);
    }
}

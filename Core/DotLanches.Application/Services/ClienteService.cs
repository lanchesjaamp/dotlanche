using DotLanches.Domain.Entities;
using DotLanches.Domain.Interfaces.Repositories;
using DotLanches.Domain.Exceptions;
using DotLanches.Domain.ValueObjects;

namespace DotLanches.Application.Services 
{
    public class ClienteService : IClienteService 
    {
        private readonly IClienteRepository _repository;

        public ClienteService(IClienteRepository repository) {
            _repository = repository;
        }

        public async Task Add(Cliente cliente)
        {
            var clienteExists = await _repository.GetByCpf(cliente.Cpf.Number!);

            if (clienteExists is null)
                await _repository.Add(cliente);
            else
                throw new ClienteAlreadyExistsException(cliente.Cpf.Number!);
        }

        public async Task<Cliente> Edit(Cliente cliente) => await _repository.Edit(cliente);

        public async Task<Cliente> Delete(int idCliente) => await _repository.Delete(idCliente);

        public async Task<IEnumerable<Cliente>> GetAll() => await _repository.GetAll();

        public async Task<Cliente?> GetByCpf(string cpf)
        {
            var cpfNumber = new Cpf(cpf);

            var cliente = await _repository.GetByCpf(cpfNumber.Number);

            if (cliente is null)
                throw new ClienteNotFoundException(cpf);

            return cliente;
        }
    }
}

using DotLanches.Domain.Entities;
using DotLanches.Domain.Interfaces.Repositories;
using DotLanches.Domain.Exceptions;
using DotLanches.Domain.ValueObjects;

namespace DotLanches.Application.UseCases
{
    public static class ClienteUseCases
    {
        public static async Task Add(Cliente cliente, IClienteRepository repository)
        {
            var clienteExists = await repository.GetByCpf(cliente.Cpf.Number!);

            if (clienteExists is null)
                await repository.Add(cliente);
            else
                throw new ClienteAlreadyExistsException(cliente.Cpf.Number!);
        }

        public static async Task<Cliente> Edit(Cliente cliente, IClienteRepository repository) => await repository.Edit(cliente);

        public static async Task<Cliente> Delete(int idCliente, IClienteRepository repository) => await repository.Delete(idCliente);

        public static async Task<IEnumerable<Cliente>> GetAll(IClienteRepository repository) => await repository.GetAll();

        public static async Task<Cliente?> GetByCpf(string cpf, IClienteRepository repository)
        {
            var cpfNumber = new Cpf(cpf);

            var cliente = await repository.GetByCpf(cpfNumber.Number);

            if (cliente is null)
                throw new ClienteNotFoundException(cpf);

            return cliente;
        }
    }
}

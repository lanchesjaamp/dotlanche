using DotLanches.Application.UseCases;
using DotLanches.Gateways;
using DotLanches.Domain.Interfaces.Repositories;
using DotLanches.Domain.Entities;

namespace DotLanches.Controllers
{
    public class AdapterClienteController
    {
        private readonly IClienteRepository _clienteRepository;

        public AdapterClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task AddCliente(Cliente cliente)
        {
            var clienteGateway = new ClienteGateway(_clienteRepository);
            await ClienteUseCases.RegisterNewCliente(cliente ,clienteGateway);
            return;
        }

        public async Task<Cliente> EditCliente(Cliente cliente)
        {
            var clienteGateway = new ClienteGateway(_clienteRepository);
            var cl = await ClienteUseCases.EditExistingCliente(cliente, clienteGateway);
            return cl;
        }

        public async Task<Cliente> DeleteCliente(int idCliente)
        {
            var clienteGateway = new ClienteGateway(_clienteRepository);
            var cl = await ClienteUseCases.RemoveCliente(idCliente, clienteGateway);
            return cl;
        }

        public async Task<IEnumerable<Cliente>> GetAllClientes()
        {
            var clienteGateway = new ClienteGateway(_clienteRepository);
            var clientes = await ClienteUseCases.ShowAllClientes(clienteGateway);
            return clientes;
        }

        public async Task<Cliente?> GetByCpf(string cpf)
        {
            var clienteGateway = new ClienteGateway(_clienteRepository);
            var cliente = await ClienteUseCases.ShowClienteByTheirCpf(cpf, clienteGateway);
            return cliente;
        }
    }
}

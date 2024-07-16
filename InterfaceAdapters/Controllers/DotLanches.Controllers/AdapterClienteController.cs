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

        public async Task Create(Cliente cliente)
        {
            var clienteGateway = new ClienteGateway(_clienteRepository);
            await ClienteUseCases.Add(cliente ,clienteGateway);
            return;
        }

        public async Task<Cliente?> GetByCpf(string cpf)
        {
            var clienteGateway = new ClienteGateway(_clienteRepository);
            var cliente = await ClienteUseCases.GetByCpf(cpf, clienteGateway);
            return cliente;
        }
    }
}

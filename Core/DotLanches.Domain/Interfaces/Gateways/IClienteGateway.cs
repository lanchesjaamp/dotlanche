using DotLanches.Domain.Entities;

namespace DotLanches.Domain.Interfaces.Gateways
{
    public interface IClienteGateway
    {
        public Task Add(Cliente cliente);

        public Task<Cliente> Edit(Cliente cliente);

        public Task<Cliente> Delete(int idCliente);

        public Task<IEnumerable<Cliente>> GetAll();

        public Task<Cliente?> GetByCpf(string cpf);
    }
}

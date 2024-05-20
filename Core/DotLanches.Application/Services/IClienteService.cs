using DotLanches.Domain.Entities;

namespace DotLanches.Application.Services
{
    public interface IClienteService
    {
        Task Add(Cliente cliente);

        Task<Cliente> Edit(Cliente cliente);

        Task<Cliente> Delete(int idCliente);

        Task<IEnumerable<Cliente>> GetAll();
    }
}
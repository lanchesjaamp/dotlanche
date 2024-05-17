using DotLanches.Domain.Entities;

namespace DotLanches.Domain.Interfaces.Repositories
{
  public interface IClienteRepository
  {
    public Task Add(Cliente cliente);

    public Task<Cliente> Edit(Cliente cliente);

    public Task<Cliente> Delete(int idCliente);

    public Task<IEnumerable<Cliente>> GetAll();
  }
}
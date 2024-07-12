using DotLanches.Domain.Entities;
using DotLanches.Domain.Interfaces.Repositories;
using DotLanches.Infra.Data;
using DotLanches.Infra.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace DotLanches.Infra.Repositories
{
    internal class ClienteRepository : IClienteRepository
    {
        private readonly DotLanchesDbContext _dbContext;

        public ClienteRepository(DotLanchesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Cliente cliente)
        {
            _dbContext.Clientes.Add(cliente);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Cliente> Edit(Cliente cliente)
        {
            var entity = _dbContext.Clientes.Find(cliente.Id) ??
                throw new EntityNotFoundException();

            _dbContext.Entry(entity).CurrentValues.SetValues(cliente);

            await _dbContext.SaveChangesAsync();

            return cliente;
        }

        public async Task<Cliente> Delete(int idCliente)
        {
            var cliente = await _dbContext.Clientes.FirstOrDefaultAsync(x => x.Id == idCliente) ??
                throw new EntityNotFoundException();

            _dbContext.Clientes.Remove(cliente);
            await _dbContext.SaveChangesAsync();

            return cliente;
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            return await _dbContext.Clientes.ToListAsync();
        }

        public async Task<Cliente?> GetByCpf(string cpf)
        {
            return await _dbContext.Clientes.FirstOrDefaultAsync(x => x.Cpf.Number == cpf);
        }

        public async Task<Cliente> GetById(int idCliente)
        {
            return await _dbContext.Clientes.FirstOrDefaultAsync(x => x.Id == idCliente) ??
                throw new EntityNotFoundException();
        }
    }
}
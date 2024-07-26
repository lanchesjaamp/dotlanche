using DotLanches.Domain.Entities;
using DotLanches.Domain.Interfaces.Repositories;
using DotLanches.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace DotLanches.Database.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly DotLanchesDbContext _dbContext;

        public CategoriaRepository(DotLanchesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Categoria>> GetAll()
        {
            return await _dbContext.Categorias.ToListAsync();
        }

        public async Task<Categoria?> GetById(int idCategoria)
        {
            return await _dbContext.Categorias.FirstOrDefaultAsync(x => x.Id == idCategoria);
        }
    }
}

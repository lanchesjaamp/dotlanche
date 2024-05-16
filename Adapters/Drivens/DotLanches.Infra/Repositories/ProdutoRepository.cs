using DotLanches.Domain.Entities;
using DotLanches.Domain.Interfaces.Repositories;
using DotLanches.Infra.Data;
using DotLanches.Infra.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace DotLanches.Infra.Repositories
{
    internal class ProdutoRepository : IProdutoRepository
    {
        private readonly DotLanchesDbContext _dbContext;

        public ProdutoRepository(DotLanchesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Produto produto)
        {
            var categoria = await _dbContext.Categorias.FirstOrDefaultAsync(c => c.Id == produto.Categoria.Id) ??
                throw new EntityNotFoundException();

            produto.Categoria = categoria;
            _dbContext.Produtos.Add(produto);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<Produto> Edit(Produto produto)
        {
            var entity = _dbContext.Produtos.Find(produto.Id) ??
                throw new EntityNotFoundException();

            _dbContext.Entry(entity).CurrentValues.SetValues(produto);

            await _dbContext.SaveChangesAsync();

            return produto;
        }

        public async Task<Produto> Delete(int idProduto)
        {
            var produto = await _dbContext.Produtos.FirstOrDefaultAsync(x => x.Id == idProduto) ??
                throw new EntityNotFoundException();

            _dbContext.Produtos.Remove(produto);
            await _dbContext.SaveChangesAsync();

            return produto;
        }

        public async Task<IEnumerable<Produto>> GetByCategoria(int idCategoria)
        {
            return await _dbContext.Produtos.Include(x => x.Categoria).Where(x => x.Categoria.Id == idCategoria).ToListAsync();
        }
    }
}
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
            var categoria = _dbContext.Categorias.Find(produto.Categoria.Id) ??
                throw new EntityNotFoundException("Categoria not found!");
            produto.Categoria = categoria;

            _dbContext.Produtos.Add(produto);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<Produto> Edit(Produto produto)
        {
            var produtoInDb = _dbContext.Produtos.Find(produto.Id) ?? 
                throw new EntityNotFoundException();

            var categoriaInDb = _dbContext.Categorias.Find(produto.Categoria.Id) ?? 
                throw new EntityNotFoundException("Categoria not found!");

            produtoInDb.Name = produto.Name;
            produtoInDb.Description = produto.Description;
            produtoInDb.Price = produto.Price;
            produtoInDb.Categoria = categoriaInDb;

            await _dbContext.SaveChangesAsync();

            return produtoInDb;
        }

        public async Task<Produto> Delete(int idProduto)
        {
            var produto = _dbContext.Produtos.Find(idProduto) ??
                throw new EntityNotFoundException();

            _dbContext.Produtos.Remove(produto);
            await _dbContext.SaveChangesAsync();

            return produto;
        }

        public async Task<IEnumerable<Produto>> GetByCategoria(int idCategoria)
        {
            return await _dbContext.Produtos.Include(x => x.Categoria).Where(x => x.Categoria.Id == idCategoria).ToListAsync();
        }

        public async Task<Produto> GetById(int idProduto)
        {
            return await _dbContext.Produtos.Include(p => p.Categoria).FirstOrDefaultAsync(p => p.Id == idProduto);
        }
    }
}
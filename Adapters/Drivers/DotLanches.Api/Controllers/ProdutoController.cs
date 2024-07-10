using DotLanches.Api.Dtos;
using DotLanches.Api.Mappers;
using DotLanches.Application.UseCases;
using DotLanches.Domain.Entities;
using DotLanches.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DotLanches.Api.Controllers
{
    [Route("[controller]")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        /// <summary>
        /// Cria um novo produto
        /// </summary>
        /// <param name="produtoDto">Dados do novo produto</param>
        /// <returns>Produto criado</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Produto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] ProdutoDto produtoDto)
        {
            await ProdutoUseCases.Add(produtoDto.ToDomainModel(), _produtoRepository);

            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        /// Atualiza um produto existente
        /// </summary>
        /// <param name="idProduto">ID do produto a ser atualizado</param>
        /// <param name="produtoDto">Novos dados do produto</param>
        /// <returns>Produto atualizado</returns>
        [HttpPut("{idProduto}")]
        [ProducesResponseType(typeof(Produto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromRoute] int idProduto, [FromBody] ProdutoDto produtoDto)
        {
            var produto = await ProdutoUseCases.Edit(produtoDto.ToDomainModel(idProduto), _produtoRepository);

            return Ok(produto);
        }

        /// <summary>
        /// Remove um produto
        /// </summary>
        /// <param name="idProduto">ID do produto a ser removido</param>
        /// <returns>Produto removido</returns>
        [HttpDelete("{idProduto}")]
        [ProducesResponseType(typeof(Produto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int idProduto)
        {
            var produto = await ProdutoUseCases.Delete(idProduto, _produtoRepository);

            return Ok(produto);
        }

        /// <summary>
        /// Busca produtos pertencentes a uma categoria
        /// </summary>
        /// <param name="idCategoria">ID da categoria a ser buscada</param>
        /// <returns>Lista de produtos que pertencem a categoria informada</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Produto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByCategoria([Required][FromQuery] int idCategoria)
        {
            var produtoList = await ProdutoUseCases.GetByCategoria(idCategoria, _produtoRepository);
            return Ok(produtoList);
        }

        /// <summary>
        /// Busca produtos pertencentes pelo Id
        /// </summary>
        /// <param name="idProduto">Id do produto a ser buscado</param>
        /// <returns>Lista de produtos pelo Id</returns>
        [HttpGet("{idProduto}")]
        [ProducesResponseType(typeof(Produto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById([Required][FromRoute] int idProduto)
        {
            var produtoList = await ProdutoUseCases.GetById(idProduto, _produtoRepository);
            return Ok(produtoList);
        }
    }
}
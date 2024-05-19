using DotLanches.Api.Dtos;
using DotLanches.Api.Mappers;
using DotLanches.Application.Services;
using DotLanches.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DotLanches.Api.Controllers
{
    [Route("[controller]")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
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
            await _produtoService.Add(produtoDto.ToDomainModel());

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
            var produto = await _produtoService.Edit(produtoDto.ToDomainModel(idProduto));

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
            var produto = await _produtoService.Delete(idProduto);

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
            var produtoList = await _produtoService.GetByCategoria(idCategoria);
            return Ok(produtoList);
        }
    }
}
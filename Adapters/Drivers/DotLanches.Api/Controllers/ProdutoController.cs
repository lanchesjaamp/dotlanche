using DotLanches.Api.Dtos;
using DotLanches.Api.Mappers;
using DotLanches.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DotLanches.Api.Controllers
{
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProdutoDto produtoDto)
        {
            await _produtoService.Add(produtoDto.ToDomainModel());

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{idProduto}")]
        public async Task<IActionResult> Update([FromRoute] int idProduto, [FromBody] ProdutoDto produtoDto)
        {
            var produto = await _produtoService.Edit(produtoDto.ToDomainModel(idProduto));

            return Ok(produto);
        }

        [HttpDelete("{idProduto}")]
        public async Task<IActionResult> Delete([FromRoute] int idProduto)
        {
            var produto = await _produtoService.Delete(idProduto);

            return Ok(produto);
        }

        [HttpGet]
        public async Task<IActionResult> GetByCategoria([Required][FromQuery] int idCategoria)
        {
            var produtoList = await _produtoService.GetByCategoria(idCategoria);
            return Ok(produtoList);
        }
    }
}
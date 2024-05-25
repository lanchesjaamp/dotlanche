using DotLanches.Api.Dtos;
using DotLanches.Api.Mappers;
using DotLanches.Application.Services;
using DotLanches.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DotLanches.Api.Controllers
{
    [Route("[controller]")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public class PagamentoController : ControllerBase
    {
        private readonly IPagamentoService _pagamentoService;

        public PagamentoController(IPagamentoService pagamentoService)
        {
            _pagamentoService = pagamentoService;
        }
    
        /// <summary>
        /// Atualiza um cliente existente
        /// </summary>
        /// <param name="idPedido">ID do pedido a ser confirmado</param>
        /// <param name="pedido">Dados do pedido a ser pago</param>
        /// <returns>Cliente atualizado</returns>
        [HttpPut("{idPedido}")]
        [ProducesResponseType(typeof(Pedido), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PayRequest([FromBody] Pedido pedido)
        {
            var payResponse = await _pagamentoService.Checkout(pedido);
            return Ok(payResponse);
        }
    }
}
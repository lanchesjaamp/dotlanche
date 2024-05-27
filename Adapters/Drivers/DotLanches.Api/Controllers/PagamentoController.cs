using DotLanches.Api.Dtos;
using DotLanches.Api.Mappers;
using DotLanches.Application.Services;
using DotLanches.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DotLanches.Api.Controllers
{
    [Route("[controller]")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public class PagamentoController : ControllerBase
    {
        private readonly IPagamentoService _pagamentoService;
        private readonly IPedidoService _pedidoService;

        public PagamentoController(IPagamentoService pagamentoService, IPedidoService pedidoService)
        {
            _pagamentoService = pagamentoService;
            _pedidoService = pedidoService;
        }

        /// <summary>
        /// Envia os dados para o meio de pagamento e retorna a senha para retirar o pedido.
        /// </summary>
        /// <param name="pagamentoRequest">Dados de requisição do pagamento</param>
        /// <returns>Situação do pagamento e senha para retirada do pedido.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(PagamentoDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ExecutePayment([Required][FromBody] PagamentoRequestDto pagamentoRequest)
        {
            var payResponse = await _pagamentoService.ProcessPagamento(pagamentoRequest.IdPedido);
            var queueKey = await _pedidoService.QueueKeyAssignment(pagamentoRequest.IdPedido);
            var pagamentoDto = payResponse.ToDtoModel(queueKey);
            return Ok(pagamentoDto);
        }
    }
}
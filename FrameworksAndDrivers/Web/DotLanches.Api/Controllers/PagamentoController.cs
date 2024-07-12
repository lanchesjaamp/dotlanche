using DotLanches.Presenters.Dtos;
using DotLanches.Controllers;
using DotLanches.Domain.Interfaces.ExternalInterfaces;
using DotLanches.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using DotLanches.Api.Dtos;

namespace DotLanches.Api.Controllers
{
    [Route("[controller]")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public class PagamentoController : ControllerBase
    {
        private readonly IPagamentoRepository _pagamentoRepository;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly ICheckout _checkout;

        public PagamentoController(IPagamentoRepository pagamentoRepository, IPedidoRepository pedidoRepository, ICheckout checkout)
        {
            _pagamentoRepository = pagamentoRepository;
            _pedidoRepository = pedidoRepository;
            _checkout = checkout;
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
            var adapterPagamento = new AdapterPagamentoController(_pagamentoRepository, _pedidoRepository, _checkout);
            var queueKey = await _pedidoRepository.AssignKey(pagamentoRequest.IdPedido);
            var payResponse = await adapterPagamento.ProcessPagamento(pagamentoRequest.IdPedido, queueKey);
            return Ok(payResponse);
        }
    }
}
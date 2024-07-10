using DotLanches.Api.Dtos;
using DotLanches.Api.Mappers;
using DotLanches.Application.UseCases;
using DotLanches.Domain.Interfaces.Repositories;
using DotLanches.Domain.Ports;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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
            var payResponse = await PagamentoUseCases.ProcessPagamento(pagamentoRequest.IdPedido, _pedidoRepository, _pagamentoRepository, _checkout);
            var queueKey = await PedidoUseCases.QueueKeyAssignment(pagamentoRequest.IdPedido, _pedidoRepository);
            var pagamentoDto = payResponse.ToDtoModel(queueKey);
            return Ok(pagamentoDto);
        }
    }
}
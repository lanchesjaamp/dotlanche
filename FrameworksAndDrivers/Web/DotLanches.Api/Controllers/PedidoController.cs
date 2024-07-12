using DotLanches.Api.Dtos;
using DotLanches.Api.Mappers;
using DotLanches.Application.UseCases;
using DotLanches.Controllers;
using DotLanches.Domain.Entities;
using DotLanches.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DotLanches.Api.Controllers
{
    [Route("[controller]")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IProdutoRepository _produtoRepository;

        public PedidoController(IPedidoRepository pedidoRepository, IProdutoRepository produtoRepository)
        {
            _pedidoRepository = pedidoRepository;
            _produtoRepository = produtoRepository;
        }

        /// <summary>
        /// Cria um novo Pedido
        /// </summary>
        /// <param name="pedidoDto">Dados do novo pedido</param>
        /// <returns>Pedido criado</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] PedidoDto pedidoDto)
        {
            var adapterPedido = new AdapterPedidoController(_produtoRepository, _pedidoRepository);
            await adapterPedido.Create(pedidoDto.ToDomainModel());
            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        /// Busca todos os pedidos
        /// </summary>
        /// <returns>Lista de pedidos</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Pedido>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var adapterPedido = new AdapterPedidoController(_produtoRepository, _pedidoRepository);
            var pedidoList = await adapterPedido.GetAll();
            return Ok(pedidoList);
        }
    }
}

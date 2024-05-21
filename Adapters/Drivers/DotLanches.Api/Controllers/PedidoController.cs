using DotLanches.Api.Dtos;
using DotLanches.Api.Mappers;
using DotLanches.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotLanches.Api.Controllers
{
    [Route("[controller]")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PedidoDto pedidoDto)
        {
            await _pedidoService.Add(pedidoDto.ToDomainModel());
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pedidoList = await _pedidoService.GetAll();
            return Ok(pedidoList);
        }
    }
}

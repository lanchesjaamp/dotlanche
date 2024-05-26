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
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        
        /// <summary>
        /// Cria um novo cliente
        /// </summary>
        /// <param name="clienteDto">Dados do novo cliente</param>
        /// <returns>Cliente criado</returns> 
        [HttpPost]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] ClienteDto clienteDto)
        {
            await _clienteService.Add(clienteDto.ToDomainModel());

            return StatusCode(StatusCodes.Status201Created);
        }
    
        /// <summary>
        /// Atualiza um cliente existente
        /// </summary>
        /// <param name="idCliente">ID do cliente a ser atualizado</param>
        /// <param name="clienteDto">Novos dados do cliente</param>
        /// <returns>Cliente atualizado</returns>
        [HttpPut("{idCliente}")]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody] ClienteDto clienteDto)
        {
            var cliente = await _clienteService.Edit(clienteDto.ToDomainModel());

            return Ok(cliente);
        }
        
        /// <summary>
        /// Remove um cliente
        /// </summary>
        /// <param name="idCliente">ID do cliente a ser removido</param>
        /// <returns>Cliente removido</returns>
        [HttpDelete("{idCliente}")]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int idCliente)
        {
            var cliente = await _clienteService.Delete(idCliente);

            return Ok(cliente);
        }
        
        /// <summary>
        /// Busca todos os clientes
        /// </summary>
        /// <returns>Lista de clientes</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Cliente>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var clienteList = await _clienteService.GetAll();
            return Ok(clienteList);
        }

        /// <summary>
        /// Busca de cliente por CPF
        /// </summary>
        /// <param name="cpf">cpf do cliente</param>
        /// <returns>Cliente</returns>
        [HttpGet("{cpf}")]
        [ProducesResponseType(typeof(IEnumerable<Cliente>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByCpf(string cpf)
        {
            var clienteList = await _clienteService.GetByCpf(cpf);
            return Ok(clienteList);
        }
    }
}
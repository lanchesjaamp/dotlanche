using DotLanches.Api.Dtos;
using DotLanches.Api.Mappers;
using DotLanches.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DotLanches.Api.Controllers
{
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ClienteDto clienteDto)
        {
            await _clienteService.Add(clienteDto.ToDomainModel());

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ClienteDto clienteDto)
        {
            var cliente = await _clienteService.Edit(clienteDto.ToDomainModel());

            return Ok(cliente);
        }

        [HttpDelete("{idCliente}")]
        public async Task<IActionResult> Delete([FromRoute] int idCliente)
        {
            var cliente = await _clienteService.Delete(idCliente);

            return Ok(cliente);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clienteList = await _clienteService.GetAll();
            return Ok(clienteList);
        }
    }
}
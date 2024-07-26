using DotLanches.Controllers;
using DotLanches.Domain.Entities;
using DotLanches.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DotLanches.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriaController : ControllerBase
{
    private readonly ICategoriaRepository _categoriaRepository;

    public CategoriaController(ICategoriaRepository categoriaRepository)
    {
        _categoriaRepository = categoriaRepository;
    }

    /// <summary>
    /// Busca todas as categorias.
    /// </summary>
    /// <returns>Lista de categorias.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Categoria>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var controller = new AdapterCategoriaController(_categoriaRepository);
        var categorias = await controller.GetAllCategorias();
        return Ok(categorias);
    }

    /// <summary>
    /// Busca categoria referente ao ID informado.
    /// </summary>
    /// <param name="idCategoria">ID da categoria a ser buscada.</param>
    /// <returns>Especificação da categoria referente ao ID.</returns>
    [HttpGet("{idCategoria}")]
    [ProducesResponseType(typeof(Categoria), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById([Required][FromRoute] int idCategoria)
    {
        var controller = new AdapterCategoriaController(_categoriaRepository);
        var categoria = await controller.GetCategoriaById(idCategoria);
        if(categoria is null) return NoContent();
        return Ok(categoria);
    }
}

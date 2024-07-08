using Anjos.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static Anjos.API.Utils.Endpoints;
using Anjos.Domain.Dto;
using Anjos.Domain.Entities;
namespace Anjos.API.Controllers;

[Route(Recursos.Categoria)]
[ApiController]
public class CategoriaController : ControllerBase
{
    private readonly ICategoriaService _categoriaService;

    public CategoriaController(ICategoriaService categoriaService)
    {
        _categoriaService = categoriaService;
    }

    [HttpGet]
    [Route(Api.Id)]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var categoria = await _categoriaService.ObterByIdAsync(id);
            return Ok(categoria);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message); 
        }
    }

    [HttpGet]
    [Route(Api.V1)]
    public async Task<IActionResult> GetCategorias([FromQuery] PaginacaoDto dto)
    {
        try
        {
            var resultado = await _categoriaService.ObterPaginadoComTotalAsync(dto);
            return Ok(resultado);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [Route(Api.V1)]
    public async Task<IActionResult> AdicionarCategoria([FromBody] CategoriaDto categoria)
    {
        try
        {
            var resultado = await _categoriaService.AdicionarCategoriaAsync(categoria);
            return CreatedAtAction(nameof(Get), new { id = resultado.Id }, resultado); // Return 201 Created
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    [Route(Api.V1)]
    public async Task<IActionResult> AtualizarCategoria([FromBody] CategoriaDto categoria)
    {
        try
        {
            var resultado = await _categoriaService.AtualizarCategoriaAsync(categoria);
            return Ok(resultado);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    [Route(Api.Id)]
    public async Task<IActionResult> DeletarCategoria(int id)
    {
        try
        {
            await _categoriaService.DeletarCategoriaAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

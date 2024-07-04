using Anjos.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static Anjos.API.Utils.Endpoints;
using Anjos.Domain.Dto;
using Anjos.Domain.Entities;
using Anjos.Application.Services;

namespace Anjos.API.Controllers;

[Route(Recursos.Entrada)]
[ApiController]
public class EntradaController : ControllerBase
{
    private readonly IEntradaService _entradaService;

    public EntradaController(IEntradaService entradaService)
    {
        _entradaService = entradaService;
    }

    [HttpGet]
    [Route(EntradaApi.ObterEntrada)]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var entrada = await _entradaService.ObterByIdAsync(id);
            return Ok(entrada);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    [Route(EntradaApi.ObterPaginado)]
    public async Task<IActionResult> GetEntradas([FromQuery] PaginacaoDto dto)
    {
        try
        {
            var resultado = await _entradaService.ObterPaginadoComTotalAsync(dto);
            return Ok(resultado);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [Route(EntradaApi.CadastrarEntrada)]
    public async Task<IActionResult> AdicionarEntrada([FromBody] EntradaDto entrada)
    {
        try
        {
            var resultado = await _entradaService.AdicionarEntradaAsync(entrada);
            return CreatedAtAction(nameof(Get), new { id = resultado.Id }, resultado);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    [Route(EntradaApi.AtualizarEntrada)]
    public async Task<IActionResult> AtualizarEntrada([FromBody] EntradaDto entrada)
    {
        try
        {
            var resultado = await _entradaService.AtualizarEntradaAsync(entrada);
            return Ok(resultado);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    [Route(EntradaApi.DeletarEntrada)]
    public async Task<IActionResult> DeletarEntrada(int id)
    {
        try
        {
            await _entradaService.DeletarEntradaAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

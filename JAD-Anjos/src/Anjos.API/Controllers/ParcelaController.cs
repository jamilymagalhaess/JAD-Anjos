using Anjos.Application.Services;
using Anjos.Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using static Anjos.API.Utils.Endpoints;

namespace Anjos.API.Controllers;

[Route(Recursos.Parcela)]
[ApiController]
public class ParcelaController : ControllerBase
{
    private readonly IParcelaService _parcelaService;

    public ParcelaController(IParcelaService parcelaService)
    {
        _parcelaService = parcelaService;
    }

    [HttpGet]
    [Route(ParcelaApi.ObterParcela)]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var parcela = await _parcelaService.ObterByIdAsync(id);
            return Ok(parcela);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    [Route(ParcelaApi.ObterPaginado)]
    public async Task<IActionResult> GetParcelas([FromQuery] PaginacaoDto dto)
    {
        try
        {
            var resultado = await _parcelaService.ObterPaginadoComTotalAsync(dto);
            return Ok(resultado);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [Route(ParcelaApi.CadastrarParcela)]
    public async Task<IActionResult> AdicionarParcela([FromBody] ParcelaDto parcela)
    {
        try
        {
            var resultado = await _parcelaService.AdicionarParcelaAsync(parcela);
            return CreatedAtAction(nameof(Get), new { id = resultado.Id }, resultado);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    [Route(ParcelaApi.AtualizarParcela)]
    public async Task<IActionResult> AtualizarParcela([FromBody] ParcelaDto parcela)
    {
        try
        {
            var resultado = await _parcelaService.AtualizarParcelaAsync(parcela);
            return Ok(resultado);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    [Route(ParcelaApi.DeletarParcela)]
    public async Task<IActionResult> DeletarParcela(int id)
    {
        try
        {
            await _parcelaService.DeletarParcelaAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

using Anjos.Application.Services;
using Anjos.Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using static Anjos.API.Utils.Endpoints;

namespace Anjos.API.Controllers;

[Route(Recursos.Conta)]
[ApiController]
public class ContaPagarController : ControllerBase
{
    private readonly IContaPagarService _contaPagarService;

    public ContaPagarController(IContaPagarService contaPagarService)
    {
        _contaPagarService = contaPagarService;
    }

    [HttpGet]
    [Route(ContaPagarApi.ObterContaPagar)]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var contaPagar = await _contaPagarService.ObterByIdAsync(id);
            return Ok(contaPagar);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    [Route(ContaPagarApi.ObterPaginado)]
    public async Task<IActionResult> GetContasPagar([FromQuery] PaginacaoDto dto)
    {
        try
        {
            var resultado = await _contaPagarService.ObterPaginadoComTotalAsync(dto);
            return Ok(resultado);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [Route(ContaPagarApi.CadastrarContaPagar)]
    public async Task<IActionResult> AdicionarContaPagar([FromBody] ContaPagarDto contaPagar)
    {
        try
        {
            var resultado = await _contaPagarService.AdicionarContaPagarAsync(contaPagar);
            return CreatedAtAction(nameof(Get), new { id = resultado.Id }, resultado);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    [Route(ContaPagarApi.AtualizarContaPagar)]
    public async Task<IActionResult> AtualizarContaPagar([FromBody] ContaPagarDto contaPagar)
    {
        try
        {
            var resultado = await _contaPagarService.AtualizarContaPagarAsync(contaPagar);
            return Ok(resultado);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    [Route(ContaPagarApi.DeletarContaPagar)]
    public async Task<IActionResult> DeletarContaPagar(int id)
    {
        try
        {
            await _contaPagarService.DeletarContaPagarAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    
}


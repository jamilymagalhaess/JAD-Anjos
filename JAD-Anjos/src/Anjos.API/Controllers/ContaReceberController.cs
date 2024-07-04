using Anjos.Domain.Dto;
using Anjos.Domain.Entities;
using Anjos.API.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Anjos.Application.Services;
using static Anjos.API.Utils.Endpoints;

namespace Anjos.API.Controllers;

[Route(Recursos.ContaReceber)]
[ApiController]
public class ContaReceberController : ControllerBase
{
    private readonly IContaReceberService _contaReceberService;

    public ContaReceberController(IContaReceberService contaReceberService)
    {
        _contaReceberService = contaReceberService;
    }

    [HttpGet]
    [Route(ContaReceberApi.ObterContaReceber)]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var contaReceber = await _contaReceberService.ObterByIdAsync(id);
            return Ok(contaReceber);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route(ContaReceberApi.ObterPaginado)]
    public async Task<IActionResult> GetContasReceber([FromQuery] PaginacaoDto dto)
    {
        try
        {
            var resultado = await _contaReceberService.ObterPaginadoComTotalAsync(dto);
            return Ok(resultado);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [Route(ContaReceberApi.CadastrarContaReceber)]
    public async Task<IActionResult> AdicionarContaReceber([FromBody] ContaReceberDto contaReceber)
    {
        try
        {
            var resultado = await _contaReceberService.AdicionarContaReceberAsync(contaReceber);
            return CreatedAtAction(nameof(Get), new { id = resultado.Id }, resultado);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    [Route(ContaReceberApi.AtualizarContaReceber)]
    public async Task<IActionResult> AtualizarContaReceber([FromBody] ContaReceberDto contaReceber)
    {
        try
        {
            var resultado = await _contaReceberService.AtualizarContaReceberAsync(contaReceber);
            return Ok(resultado);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    [Route(ContaReceberApi.DeletarContaReceber)]
    public async Task<IActionResult> DeletarContaReceber(int id)
    {
        try
        {
            await _contaReceberService.DeletarContaReceberAsync(id);
            return Ok();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

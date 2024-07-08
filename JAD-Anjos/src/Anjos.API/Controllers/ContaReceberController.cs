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
    [Route(Api.Id)]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var contaReceber = await _contaReceberService.ObterByIdAsync(id);
            return Ok(contaReceber);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route(Api.V1)]
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
    [Route(Api.V1)]
    public async Task<IActionResult> AdicionarContaReceber([FromBody] ContaReceberDto contaReceber)
    {
        try
        {
            await _contaReceberService.AdicionarContaReceberAsync(contaReceber);
            return Created();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    [Route(Api.V1)]
    public async Task<IActionResult> AtualizarContaReceber([FromBody] ContaReceberDto contaReceber)
    {
        try
        {
            var resultado = await _contaReceberService.AtualizarContaReceberAsync(contaReceber);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    [Route(Api.Id)]
    public async Task<IActionResult> DeletarContaReceber(int id)
    {
        try
        {
            await _contaReceberService.DeletarContaReceberAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

﻿using Anjos.Application.Interfaces;
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
    [Route(Api.Id)]
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
    [Route(Api.V1)]
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
    [Route(Api.V1)]
    public async Task<IActionResult> AdicionarEntrada([FromBody] EntradaDto entrada)
    {
        try
        {
            await _entradaService.AdicionarEntradaAsync(entrada);
            return Created();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    [Route(Api.V1)]
    public async Task<IActionResult> AtualizarEntrada([FromBody] EntradaDto entrada)
    {
        try
        {
            await _entradaService.AtualizarEntradaAsync(entrada);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    [Route(Api.Id)]
    public async Task<IActionResult> DeletarEntrada(int id)
    {
        try
        {
            await _entradaService.DeletarEntradaAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
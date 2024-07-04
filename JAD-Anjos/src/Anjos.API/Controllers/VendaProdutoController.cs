using Anjos.Application.Services;
using Anjos.Domain.Dto;
using Anjos.Domain.Entities;
using Anjos.API.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Anjos.API.Utils.Endpoints;

namespace Anjos.API.Controllers;

[Route(Recursos.VendaProduto)]
[ApiController]
public class VendaProdutoController : ControllerBase
{
    private readonly IVendaProdutoService _vendaProdutoService;

    public VendaProdutoController(IVendaProdutoService vendaProdutoService)
    {
        _vendaProdutoService = vendaProdutoService;
    }

    [HttpGet]
    [Route(VendaProdutoApi.ObterVendaProduto)]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var vendaProduto = await _vendaProdutoService.ObterByIdAsync(id);
            return Ok(vendaProduto);
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
    [Route(VendaProdutoApi.ObterPorVenda)]
    public async Task<IActionResult> GetPorVenda(int vendaId)
    {
        try
        {
            var vendaProdutos = await _vendaProdutoService.ObterPorVendaIdAsync(vendaId);
            return Ok(vendaProdutos);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [Route(VendaProdutoApi.AdicionarVendaProduto)]
    public async Task<IActionResult> AdicionarVendaProduto([FromBody] VendaProdutoDto vendaProdutoDto)
    {
        try
        {
            await _vendaProdutoService.AdicionarVendaProdutoAsync(vendaProdutoDto);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    [Route(VendaProdutoApi.AtualizarVendaProduto)]
    public async Task<IActionResult> AtualizarVendaProduto([FromBody] VendaProdutoDto vendaProdutoDto)
    {
        try
        {
            await _vendaProdutoService.AtualizarVendaProdutoAsync(vendaProdutoDto);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    [Route(VendaProdutoApi.DeletarVendaProduto)]
    public async Task<IActionResult> DeletarVendaProduto(int id)
    {
        try
        {
            await _vendaProdutoService.DeletarVendaProdutoAsync(id);
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

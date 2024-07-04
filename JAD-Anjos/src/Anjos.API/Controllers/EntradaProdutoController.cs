using Anjos.Application.Services;
using Anjos.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using static Anjos.API.Utils.Endpoints;

namespace Anjos.API.Controllers;

[Route(Recursos.EntradaProduto)]
[ApiController]
public class EntradaProdutoController : ControllerBase
{
    private readonly IEntradaProdutoService _entradaProdutoService;

    public EntradaProdutoController(IEntradaProdutoService entradaProdutoService)
    {
        _entradaProdutoService = entradaProdutoService;
    }

    [HttpGet]
    [Route(EntradaProdutoApi.ObterEntradaProduto)]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var entradaProduto = await _entradaProdutoService.ObterByIdAsync(id);
            return Ok(entradaProduto);
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
    [Route(EntradaProdutoApi.ObterPorEntrada)]
    public async Task<IActionResult> GetPorEntrada(int entradaId)
    {
        try
        {
            var entradaProdutos = await _entradaProdutoService.ObterPorEntradaIdAsync(entradaId);
            return Ok(entradaProdutos);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [Route(EntradaProdutoApi.AdicionarEntradaProduto)]
    public async Task<IActionResult> AdicionarEntradaProduto([FromBody] EntradaProduto entradaProduto)
    {
        try
        {
            await _entradaProdutoService.AdicionarEntradaProdutoAsync(entradaProduto);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    [Route(EntradaProdutoApi.AtualizarEntradaProduto)]
    public async Task<IActionResult> AtualizarEntradaProduto([FromBody] EntradaProduto entradaProduto)
    {
        try
        {
            await _entradaProdutoService.AtualizarEntradaProdutoAsync(entradaProduto);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    [Route(EntradaProdutoApi.DeletarEntradaProduto)]
    public async Task<IActionResult> DeletarEntradaProduto(int id)
    {
        try
        {
            await _entradaProdutoService.DeletarEntradaProdutoAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

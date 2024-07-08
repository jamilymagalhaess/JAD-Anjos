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
    [Route(Api.Id)]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var entradaProduto = await _entradaProdutoService.ObterByIdAsync(id);
            return Ok(entradaProduto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route(Api.V1)]
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
    [Route(Api.V1)]
    public async Task<IActionResult> AdicionarEntradaProduto([FromBody] EntradaProduto entradaProduto)
    {
        try
        {
            await _entradaProdutoService.AdicionarEntradaProdutoAsync(entradaProduto);
            return Created();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    [Route(Api.V1)]
    public async Task<IActionResult> AtualizarEntradaProduto([FromBody] EntradaProduto entradaProduto)
    {
        try
        {
            await _entradaProdutoService.AtualizarEntradaProdutoAsync(entradaProduto);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    [Route(Api.Id)]
    public async Task<IActionResult> DeletarEntradaProduto(int id)
    {
        try
        {
            await _entradaProdutoService.DeletarEntradaProdutoAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

using Anjos.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static Anjos.API.Utils.Endpoints;
using Anjos.Domain.Dto;
using System.Net;
using Anjos.API.Utils;

namespace Anjos.API.Controllers;

[Route(Recursos.Produto)]
[ApiController]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoService _produtoService;
    public ProdutoController(IProdutoService produtoService)
    {
        _produtoService = produtoService;
    }

    [HttpGet]
    [Route(Produto.ObterProduto)]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var produto = await _produtoService.ObterByIdAsync(id);
            return Ok(produto);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    [HttpGet]
    [Route(Produto.ObterPaginado)]
    public async Task<IActionResult> GetProdutos([FromQuery] Paginacao dto)
    {
        try
        {
            var resultado = await _produtoService.ObterPaginadoComTotalAsync(dto);
            return Ok(resultado);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route(Produto.CadastrarProduto)]
    public async Task<IActionResult> AdicionarProduto([FromQuery] Domain.Entities.Produto produto)
    {
        try
        {
            var resultado = await _produtoService.AdicionarProdutoAsync(produto);
            return Ok(resultado);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}
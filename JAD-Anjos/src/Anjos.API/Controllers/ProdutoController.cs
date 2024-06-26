using Anjos.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static Anjos.API.Utils.Endpoints;
using Anjos.Domain.Dto;
using System.Net;

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

    /*[HttpGet]
    [Route(Produto.ObterProduto)]
    [ProducesResponseType(typeof(Produto), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(Produto), (int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> Get([FromQuery] int id) => await _produtoService.ObterByIdAsync(id).Resultado();*/


    [HttpGet]
    [Route(Produto.ObterPaginado)]
    [ProducesResponseType(typeof(PaginacaoResultado), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(PaginacaoResultado), (int)HttpStatusCode.NotFound)]
    public Task<PaginacaoResultado> GetProdutos([FromQuery] Paginacao dto) => _produtoService.ObterPaginadoComTotalAsync(dto);

        
}
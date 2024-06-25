using Anjos.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static Anjos.API.Utils.Endpoints;

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
        var produtos = await _produtoService.ObterByIdAsync(id);
        return Ok(produtos);
    }
}
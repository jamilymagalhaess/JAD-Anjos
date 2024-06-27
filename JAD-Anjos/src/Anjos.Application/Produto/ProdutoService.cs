using Anjos.Database.Repositories.Produto;
using Anjos.Application.Interfaces;
using Anjos.Domain.Entities;
using Anjos.Domain.Dto;
using Microsoft.EntityFrameworkCore;

namespace Anjos.Application.Services;

public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoService(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<Produto?> ObterByIdAsync(int id)
    {
            var produto = await _produtoRepository.ObterByIdAsync(id);
            if (produto == null) throw new KeyNotFoundException($"Produto com ID {id} não encontrado.");

            return produto; 
    }

   public async Task<PaginacaoResultado> ObterPaginadoComTotalAsync(Paginacao dto)
    {
        if (dto.Pagina <= 0) throw new ArgumentException("O número da pagina não pode ser vazio.");
        if (!string.IsNullOrEmpty(dto.DirecaoDaOrdenacao) && (dto.DirecaoDaOrdenacao.ToLower() != "asc" && dto.DirecaoDaOrdenacao.ToLower() != "desc")) throw new ArgumentException("Direção de ordenação inválida. Use 'asc' ou 'desc'.");
        if (string.IsNullOrEmpty(dto.DirecaoDaOrdenacao)) dto.DirecaoDaOrdenacao = "asc";
        if (string.IsNullOrEmpty(dto.Ordenacao)) dto.Ordenacao = "Nome";
        if (dto.Itens <= 0) dto.Itens = 10;

        var produtos = await _produtoRepository.ObterPaginadoAsync(dto);
        var total = await _produtoRepository.ObterTotalProdutosAsync(dto.Filtro);
        int totalPagina = (int)Math.Ceiling((double)total / dto.Itens);

        var result = new PaginacaoResultado
        {
            Total = total,
            Pagina = dto.Pagina,
            Itens = dto.Itens,
            TotalPagina = totalPagina,
            Produtos = produtos.ToList()
        };

        return result;
    }


}

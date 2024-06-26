using Microsoft.EntityFrameworkCore;
using Anjos.Database.Context;
using System;
using Anjos.Domain.Dto;

namespace Anjos.Database.Repositories.Produto;

public class ProdutoRepository : Repository<Domain.Entities.Produto>, IProdutoRepository
{
    public ProdutoRepository(AnjosContext context) : base(context)
    {
    }
    public async Task<Domain.Entities.Produto?> ObterByIdAsync(int id)
    {
        return await _context.Produto.FindAsync(id);
    }

    public async Task<int> ObterTotalProdutosAsync(int? filter)
    {
        var query = _context.Produto.AsQueryable();

        if (filter.HasValue)
        {
            query = query.Where(p => p.CategoriaId == filter.Value);
        }

        return await query.CountAsync();
    }

    public async Task<IEnumerable<Domain.Entities.Produto>> ObterPaginadoAsync(Paginacao dto)
    {
        var query = _context.Produto.AsQueryable();

        if (dto.Filtro.HasValue)
        {
            query = query.Where(p => p.CategoriaId == dto.Filtro.Value);
        }

        query = AplicarOrdenacao(query, dto.Ordenacao, dto.DirecaoDaOrdenacao);

        return await query.Skip((dto.Pagina - 1) * dto.Itens).Take(dto.Itens).ToListAsync();
    }


    public IQueryable<Domain.Entities.Produto> AplicarOrdenacao( IQueryable<Domain.Entities.Produto> query, string ordenacao, string direcaoDaOrdenacao)
    {
        switch (ordenacao.ToLower())
        {
            case "descricao":
                query = direcaoDaOrdenacao.ToLower() == "desc" ? query.OrderByDescending(p => p.Descricao) : query.OrderBy(p => p.Descricao);
                break;
            case "quantidade":
                query = direcaoDaOrdenacao.ToLower() == "desc" ? query.OrderByDescending(p => p.Quantidade) : query.OrderBy(p => p.Quantidade);
                break;
            case "valor":
                query = direcaoDaOrdenacao.ToLower() == "desc" ? query.OrderByDescending(p => p.Valor) : query.OrderBy(p => p.Valor);
                break;
            case "id":
                query = direcaoDaOrdenacao.ToLower() == "desc" ? query.OrderByDescending(p => p.Id) : query.OrderBy(p => p.Id);     
                break;
            default:
                query = direcaoDaOrdenacao.ToLower() == "desc" ? query.OrderByDescending(p => p.Nome) : query.OrderBy(p => p.Nome);
                break;
        }
        return query;
    }


}

using Microsoft.EntityFrameworkCore;
using Anjos.Database.Context;
using Anjos.Domain.Entities;
using Anjos.Domain.Dto;
using System.Linq.Expressions;
using Anjos.Database.Repositories.Base;

namespace Anjos.Database.Repositories;

public class ProdutoRepository : Repository<Produto>, IProdutoRepository
{
    public ProdutoRepository(AnjosContext context) : base(context)
    {
    }
    public async Task<Produto?> ObterByIdAsync(int id)
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
    public async Task Atualizar(Produto produto)
    {
        _context.Produto.Update(produto);
        await _context.SaveChangesAsync();
    }
    public async Task Deletar(Produto produto)
    {
        _context.Produto.Remove(produto);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Produto>> ObterPaginadoAsync(PaginacaoDto dto)
    {
        var query = _context.Set<Produto>().AsQueryable();

        if (dto.Filtro.HasValue)
        {
            query = query.Where(p => p.CategoriaId == dto.Filtro.Value);
        }

        var orderByMappings = new Dictionary<string, Expression<Func<Produto, object>>>
        {
            { "descricao", p => p.Descricao },
            { "quantidade", p => p.Quantidade },
            { "valor", p => p.Valor },
            { "id", p => p.Id },
            { "nome", p => p.Nome }
        };

        query = AplicarOrdenacao(query, dto.Ordenacao, dto.DirecaoDaOrdenacao, orderByMappings);

        return await ObterPaginadoAsync(query, dto.Pagina, dto.Itens);
    }

}

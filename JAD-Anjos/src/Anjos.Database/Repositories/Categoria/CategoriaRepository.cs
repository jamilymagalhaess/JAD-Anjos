using Microsoft.EntityFrameworkCore;
using Anjos.Database.Context;
using Anjos.Domain.Entities;
using Anjos.Domain.Dto;
using System.Linq.Expressions;
using Anjos.Database.Repositories.Base;

namespace Anjos.Database.Repositories;

public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
{

    public CategoriaRepository(AnjosContext context) : base(context)
    {
    }

    public async Task<Categoria> ObterByIdAsync(int id)
    {
        return await _context.Categoria.FindAsync(id);
    }

    public async Task<int> ObterTotalCategoriasAsync(int? filtro)
    {
        var query = _context.Categoria.AsQueryable();

        if (filtro.HasValue)
        {
            query = query.Where(c => c.Id == filtro.Value);
        }

        return await query.CountAsync();
    }

    public async Task Atualizar(Categoria categoria)
    {
        _context.Categoria.Update(categoria);
        await _context.SaveChangesAsync();
    }
    public async Task Deletar(Categoria categoria)
    {
        _context.Categoria.Remove(categoria);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Categoria>> ObterPaginadoAsync(PaginacaoDto dto)
    {
        var query = _context.Categoria.AsQueryable();

        if (dto.Filtro.HasValue)
        {
            query = query.Where(c => c.Id == dto.Filtro.Value);
        }

        var orderByMappings = new Dictionary<string, Expression<Func<Categoria, object>>>
        {
            { "descricao", c => c.Descricao },
            { "id", c => c.Id },
            { "nome", c => c.Nome }
        };

        query = AplicarOrdenacao(query, dto.Ordenacao, dto.DirecaoDaOrdenacao, orderByMappings);

        return await ObterPaginadoAsync(query, dto.Pagina, dto.Itens);
    }

}

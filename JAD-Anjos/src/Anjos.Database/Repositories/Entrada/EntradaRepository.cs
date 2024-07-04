using Microsoft.EntityFrameworkCore;
using Anjos.Database.Context;
using Anjos.Domain.Entities;
using Anjos.Domain.Dto;
using System.Linq.Expressions;
using Anjos.Database.Repositories.Base;

namespace Anjos.Database.Repositories;

public class EntradaRepository : Repository<Entrada>, IEntradaRepository
{
    public EntradaRepository(AnjosContext context) : base(context)
    {
    }

    public async Task<Entrada> ObterByIdAsync(int id)
    {
        return await _context.Entrada
                             .Include(e => e.EntradaProduto)
                             .Include(e => e.ContaPagar)
                             .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<int> ObterTotalEntradasAsync(int? filtro)
    {
        var query = _context.Entrada.AsQueryable();

        if (filtro.HasValue)
        {
            query = query.Where(e => e.Id == filtro.Value);
        }

        return await query.CountAsync();
    }

    public async Task Atualizar(Entrada entrada)
    {
        _context.Entrada.Update(entrada);
        await _context.SaveChangesAsync();
    }

    public async Task Deletar(Entrada entrada)
    {
        _context.Entrada.Remove(entrada);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Entrada>> ObterPaginadoAsync(PaginacaoDto dto)
    {
        var query = _context.Entrada.AsQueryable();

        if (dto.Filtro.HasValue)
        {
            query = query.Where(e => e.Id == dto.Filtro.Value);
        }

        var orderByMappings = new Dictionary<string, Expression<Func<Entrada, object>>>
        {
            { "valor", e => e.Valor },
            { "id", e => e.Id }
        };

        query = AplicarOrdenacao(query, dto.Ordenacao, dto.DirecaoDaOrdenacao, orderByMappings);

        return await ObterPaginadoAsync(query, dto.Pagina, dto.Itens);
    }
}

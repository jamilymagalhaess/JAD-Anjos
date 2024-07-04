using Microsoft.EntityFrameworkCore;
using Anjos.Database.Context;
using Anjos.Domain.Entities;
using Anjos.Domain.Dto;
using Anjos.Database.Repositories.Base;
using System.Linq.Expressions;

namespace Anjos.Database.Repositories;

public class ParcelaRepository : Repository<Parcela>, IParcelaRepository
{
    public ParcelaRepository(AnjosContext context) : base(context)
    {
    }

    public async Task<Parcela> ObterByIdAsync(int id)
    {
        return await _context.Parcela.FindAsync(id);
    }

    public async Task<int> ObterTotalParcelasAsync(int? filtro)
    {
        var query = _context.Parcela.AsQueryable();

        if (filtro.HasValue)
        {
            query = query.Where(p => p.Id == filtro.Value);
        }

        return await query.CountAsync();
    }

    public async Task Atualizar(Parcela parcela)
    {
        _context.Parcela.Update(parcela);
        await _context.SaveChangesAsync();
    }

    public async Task Deletar(Parcela parcela)
    {
        _context.Parcela.Remove(parcela);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Parcela>> ObterPaginadoAsync(PaginacaoDto dto)
    {
        var query = _context.Parcela.AsQueryable();

        if (dto.Filtro.HasValue)
        {
            query = query.Where(p => p.Id == dto.Filtro.Value);
        }

        var orderByMappings = new Dictionary<string, Expression<Func<Parcela, object>>>
        {
            { "id", p => p.Id },
            { "dataVencimento", p => p.DataVencimento },
            { "valor", p => p.Valor }
        };

        query = AplicarOrdenacao(query, dto.Ordenacao, dto.DirecaoDaOrdenacao, orderByMappings);

        return await ObterPaginadoAsync(query, dto.Pagina, dto.Itens);
    }
}

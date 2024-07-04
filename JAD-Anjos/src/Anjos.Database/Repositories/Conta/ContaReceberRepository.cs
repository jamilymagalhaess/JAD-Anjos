using Microsoft.EntityFrameworkCore;
using Anjos.Database.Context;
using Anjos.Domain.Entities;
using Anjos.Domain.Dto;
using Anjos.Database.Repositories.Base;
using System.Linq.Expressions;

namespace Anjos.Database.Repositories;

public class ContaReceberRepository : Repository<ContaReceber>, IContaReceberRepository
{
    public ContaReceberRepository(AnjosContext context) : base(context)
    {
    }

    public async Task<ContaReceber> ObterByIdAsync(int id)
    {
        return await _context.ContaReceber.FindAsync(id);
    }

    public async Task<int> ObterTotalContasReceberAsync(int? filtro)
    {
        var query = _context.ContaReceber.AsQueryable();

        if (filtro.HasValue)
        {
            query = query.Where(p => p.Id == filtro.Value);
        }

        return await query.CountAsync();
    }

    public async Task Atualizar(ContaReceber contaReceber)
    {
        _context.ContaReceber.Update(contaReceber);
        await _context.SaveChangesAsync();
    }

    public async Task Deletar(ContaReceber contaReceber)
    {
        _context.ContaReceber.Remove(contaReceber);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<ContaReceber>> ObterPaginadoAsync(PaginacaoDto dto)
    {
        var query = _context.ContaReceber.AsQueryable();

        if (dto.Filtro.HasValue)
        {
            query = query.Where(p => p.Id == dto.Filtro.Value);
        }

        var orderByMappings = new Dictionary<string, Expression<Func<ContaReceber, object>>>
        {
            { "id", p => p.Id },
            { "valor", p => p.Valor }
        };

        query = AplicarOrdenacao(query, dto.Ordenacao, dto.DirecaoDaOrdenacao, orderByMappings);

        return await ObterPaginadoAsync(query, dto.Pagina, dto.Itens);
    }
}

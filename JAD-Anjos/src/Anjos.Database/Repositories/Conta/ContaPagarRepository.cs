using Microsoft.EntityFrameworkCore;
using Anjos.Database.Context;
using Anjos.Domain.Entities;
using Anjos.Domain.Dto;
using Anjos.Database.Repositories.Base;
using System.Linq.Expressions;

namespace Anjos.Database.Repositories;

public class ContaPagarRepository : Repository<ContaPagar>, IContaPagarRepository
{
    public ContaPagarRepository(AnjosContext context) : base(context)
    {
    }

    public async Task<ContaPagar> ObterByIdAsync(int id)
    {
        return await _context.ContaPagar.FindAsync(id);
    }

    public async Task<int> ObterTotalContasPagarAsync(int? filtro)
    {
        var query = _context.ContaPagar.AsQueryable();

        if (filtro.HasValue)
        {
            query = query.Where(cp => cp.Id == filtro.Value);
        }

        return await query.CountAsync();
    }

    public async Task Atualizar(ContaPagar contaPagar)
    {
        _context.ContaPagar.Update(contaPagar);
        await _context.SaveChangesAsync();
    }

    public async Task Deletar(ContaPagar contaPagar)
    {
        _context.ContaPagar.Remove(contaPagar);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<ContaPagar>> ObterPaginadoAsync(PaginacaoDto dto)
    {
        var query = _context.ContaPagar.AsQueryable();

        if (dto.Filtro.HasValue)
        {
            query = query.Where(cp => cp.Id == dto.Filtro.Value);
        }

        var orderByMappings = new Dictionary<string, Expression<Func<ContaPagar, object>>>
        {
            { "id", cp => cp.Id },
            { "valor", cp => cp.Valor },
            { "quantidadeParcelas", cp => cp.QuantidadeParcelas }
        };

        query = AplicarOrdenacao(query, dto.Ordenacao, dto.DirecaoDaOrdenacao, orderByMappings);

        return await ObterPaginadoAsync(query, dto.Pagina, dto.Itens);
    }
}

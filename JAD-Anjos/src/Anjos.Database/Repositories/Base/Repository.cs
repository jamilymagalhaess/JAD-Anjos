using Microsoft.EntityFrameworkCore;
using Anjos.Database.Context;
using Anjos.Domain.Entities;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Anjos.Database.Repositories.Base;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly AnjosContext _context;

    protected Repository(AnjosContext context)
    {
        _context = context;
    }

    public virtual async Task<TEntity> Adicionar(TEntity entidade)
    {
        var entity = await _context.AddAsync(entidade);
        await _context.SaveChangesAsync();
        return entity.Entity;
    }

    public virtual async Task Remover(TEntity entidade)
    {
        _context.Remove(entidade);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<TEntity>> ObterPaginadoAsync(IQueryable<TEntity> query, int pagina, int itens)
    {
        return await query.Skip((pagina - 1) * itens).Take(itens).ToListAsync();
    }

    public IQueryable<TEntity> AplicarOrdenacao(IQueryable<TEntity> query, string ordenacao, string direcaoDaOrdenacao, Dictionary<string, Expression<Func<TEntity, object>>> orderByMappings)
    {
        if (orderByMappings.TryGetValue(ordenacao.ToLower(), out var orderByExpression))
        {
            if (direcaoDaOrdenacao.ToLower() == "desc")
            {
                query = query.OrderByDescending(orderByExpression);
            }
            else
            {
                query = query.OrderBy(orderByExpression);
            }
        }
        return query;
    }
}

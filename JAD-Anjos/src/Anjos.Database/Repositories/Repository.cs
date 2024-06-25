using Microsoft.EntityFrameworkCore;
using Anjos.Database.Context;
using Anjos.Domain.Entities;
using System.Threading.Tasks;

namespace Anjos.Database.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly AnjosContext _context;

        protected Repository(AnjosContext context)
        {
            _context = context;
        }

        public virtual async Task Adicionar(TEntity entidade)
        {
            await _context.AddAsync(entidade);
            await _context.SaveChangesAsync();
        }

        public virtual async Task Remover(TEntity entidade)
        {
            _context.Remove(entidade);
            await _context.SaveChangesAsync();
        }
    }
}

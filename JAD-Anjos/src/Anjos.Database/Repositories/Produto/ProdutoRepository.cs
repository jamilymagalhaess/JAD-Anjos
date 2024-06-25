using Microsoft.EntityFrameworkCore;
using Anjos.Database.Context;
using Anjos.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Anjos.Database.Repositories.Produto
{
    public class ProdutoRepository : Repository<Domain.Entities.Produto>, IProdutoRepository
    {
        public ProdutoRepository(AnjosContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Domain.Entities.Produto>> ObterTodosAsync()
        {
            return await _context.Produto.ToListAsync();
        }
        public async Task<Domain.Entities.Produto?> ObterByIdAsync(int id)
        {
            return await _context.Produto.FindAsync(id);
        }
    }
}

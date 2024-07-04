using Anjos.Database.Context;
using Anjos.Database.Repositories.Base;
using Anjos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Anjos.Database.Repositories
{
    public class VendaProdutoRepository : Repository<VendaProduto>, IVendaProdutoRepository
    {
        public VendaProdutoRepository(AnjosContext context) : base(context)
        {
        }

        public async Task<VendaProduto> ObterByIdAsync(int id)
        {
            return await _context.VendaProduto.FindAsync(id);
        }

        public async Task<IEnumerable<VendaProduto>> ObterPorVendaIdAsync(int vendaId)
        {
            return await _context.VendaProduto
                .Include(vp => vp.Produto)
                .Where(vp => vp.VendaId == vendaId)
                .ToListAsync();
        }

        public async Task Adicionar(VendaProduto vendaProduto)
        {
            await _context.VendaProduto.AddAsync(vendaProduto);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(VendaProduto vendaProduto)
        {
            _context.VendaProduto.Update(vendaProduto);
            await _context.SaveChangesAsync();
        }

        public async Task Deletar(VendaProduto vendaProduto)
        {
            _context.VendaProduto.Remove(vendaProduto);
            await _context.SaveChangesAsync();
        }
    }
}

using Anjos.Database.Context;
using Anjos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anjos.Database.Repositories;

public class EntradaProdutoRepository : IEntradaProdutoRepository
{
    private readonly AnjosContext _context;

    public EntradaProdutoRepository(AnjosContext context)
    {
        _context = context;
    }

    public async Task<EntradaProduto> ObterByIdAsync(int id)
    {
        return await _context.EntradaProduto.FindAsync(id);
    }

    public async Task<IEnumerable<EntradaProduto>> ObterPorEntradaIdAsync(int entradaId)
    {
        return await _context.EntradaProduto
            .Where(ep => ep.EntradaId == entradaId)
            .ToListAsync();
    }

    public async Task Adicionar(EntradaProduto entradaProduto)
    {
        await _context.EntradaProduto.AddAsync(entradaProduto);
        await _context.SaveChangesAsync();
    }

    public async Task Atualizar(EntradaProduto entradaProduto)
    {
        _context.EntradaProduto.Update(entradaProduto);
        await _context.SaveChangesAsync();
    }

    public async Task Deletar(EntradaProduto entradaProduto)
    {
        _context.EntradaProduto.Remove(entradaProduto);
        await _context.SaveChangesAsync();
    }
}

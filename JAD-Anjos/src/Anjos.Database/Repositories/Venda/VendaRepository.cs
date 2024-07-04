using Microsoft.EntityFrameworkCore;
using Anjos.Database.Context;
using Anjos.Domain.Entities;
using Anjos.Domain.Dto;
using Anjos.Database.Repositories.Base;
using System.Linq.Expressions;

namespace Anjos.Database.Repositories
{
    public class VendaRepository : Repository<Venda>, IVendaRepository
    {
        public VendaRepository(AnjosContext context) : base(context)
        {
        }

        public async Task<Venda> ObterByIdAsync(int id)
        {
            return await _context.Venda.FindAsync(id);
        }

        public async Task<int> ObterTotalVendasAsync(int? filtro)
        {
            var query = _context.Venda.AsQueryable();

            if (filtro.HasValue)
            {
                query = query.Where(v => v.Id == filtro.Value);
            }

            return await query.CountAsync();
        }

        public async Task Atualizar(Venda venda)
        {
            _context.Venda.Update(venda);
            await _context.SaveChangesAsync();
        }

        public async Task Deletar(Venda venda)
        {
            _context.Venda.Remove(venda);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Venda>> ObterPaginadoAsync(PaginacaoDto dto)
        {
            var query = _context.Venda.AsQueryable();

            if (dto.Filtro.HasValue)
            {
                query = query.Where(v => v.Id == dto.Filtro.Value);
            }

            var orderByMappings = new Dictionary<string, Expression<Func<Venda, object>>>
            {
                { "id", v => v.Id },
                { "dataVenda", v => v.DataVenda },
                { "valor", v => v.Valor }
            };

            query = AplicarOrdenacao(query, dto.Ordenacao, dto.DirecaoDaOrdenacao, orderByMappings);

            return await ObterPaginadoAsync(query, dto.Pagina, dto.Itens);
        }
    }
}

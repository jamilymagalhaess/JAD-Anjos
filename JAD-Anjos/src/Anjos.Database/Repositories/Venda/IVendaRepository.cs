using Anjos.Domain.Entities;
using Anjos.Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;
using Anjos.Database.Repositories.Base;

namespace Anjos.Database.Repositories;

public interface IVendaRepository : IRepository<Venda>
{
    Task<Venda> ObterByIdAsync(int id);
    Task<int> ObterTotalVendasAsync(int? filtro);
    Task Atualizar(Venda venda);
    Task Deletar(Venda venda);
    Task<IEnumerable<Venda>> ObterPaginadoAsync(PaginacaoDto dto);
}

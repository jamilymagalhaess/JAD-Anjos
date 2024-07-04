using Anjos.Domain.Entities;
using Anjos.Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;
using Anjos.Database.Repositories.Base;

namespace Anjos.Database.Repositories;

public interface IContaReceberRepository : IRepository<ContaReceber>
{
    Task<ContaReceber> ObterByIdAsync(int id);
    Task<int> ObterTotalContasReceberAsync(int? filtro);
    Task Atualizar(ContaReceber contaReceber);
    Task Deletar(ContaReceber contaReceber);
    Task<IEnumerable<ContaReceber>> ObterPaginadoAsync(PaginacaoDto dto);
}

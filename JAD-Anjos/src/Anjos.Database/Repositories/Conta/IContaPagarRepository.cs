using Anjos.Domain.Entities;
using Anjos.Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;
using Anjos.Database.Repositories.Base;

namespace Anjos.Database.Repositories;

public interface IContaPagarRepository : IRepository<ContaPagar>
{
    Task<ContaPagar> ObterByIdAsync(int id);
    Task<int> ObterTotalContasPagarAsync(int? filtro);
    Task Atualizar(ContaPagar contaPagar);
    Task Deletar(ContaPagar contaPagar);
    Task<IEnumerable<ContaPagar>> ObterPaginadoAsync(PaginacaoDto dto);
}

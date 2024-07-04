using Anjos.Domain.Entities;
using Anjos.Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;
using Anjos.Database.Repositories.Base;

namespace Anjos.Database.Repositories;

public interface IEntradaRepository : IRepository<Entrada>
{
    Task<Entrada> ObterByIdAsync(int id);
    Task<int> ObterTotalEntradasAsync(int? filtro);
    Task Atualizar(Entrada entrada);
    Task Deletar(Entrada entrada);
    Task<IEnumerable<Entrada>> ObterPaginadoAsync(PaginacaoDto dto);
    Task<Entrada> Adicionar(Entrada entrada);
}

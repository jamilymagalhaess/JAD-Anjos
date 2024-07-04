using Anjos.Domain.Entities;
using Anjos.Domain.Dto;
using Anjos.Database.Repositories.Base;

namespace Anjos.Database.Repositories;

public interface IParcelaRepository : IRepository<Parcela>
{
    Task<Parcela> ObterByIdAsync(int id);
    Task<int> ObterTotalParcelasAsync(int? filtro);
    Task Atualizar(Parcela parcela);
    Task Deletar(Parcela parcela);
    Task<IEnumerable<Parcela>> ObterPaginadoAsync(PaginacaoDto dto);
    Task<Parcela> Adicionar(Parcela parcela);
}

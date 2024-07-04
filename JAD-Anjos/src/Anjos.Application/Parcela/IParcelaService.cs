using Anjos.Domain.Dto;
using Anjos.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Anjos.Application.Services;

public interface IParcelaService
{
    Task<Parcela> ObterByIdAsync(int id);
    Task<PaginacaoResultadoDto> ObterPaginadoComTotalAsync(PaginacaoDto dto);
    Task<Parcela> AdicionarParcelaAsync(ParcelaDto parcelaDto);
    Task<Parcela> AtualizarParcelaAsync(ParcelaDto parcelaDto);
    Task DeletarParcelaAsync(int id);
}

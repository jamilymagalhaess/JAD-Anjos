using Anjos.Domain.Dto;
using Anjos.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Anjos.Application.Services;

public interface IEntradaService
{
    Task<Entrada> ObterByIdAsync(int id);
    Task<PaginacaoResultadoDto> ObterPaginadoComTotalAsync(PaginacaoDto dto);
    Task<Entrada> AdicionarEntradaAsync(EntradaDto entradaDto);
    Task<Entrada> AtualizarEntradaAsync(EntradaDto entradaDto);
    Task DeletarEntradaAsync(int id);
}

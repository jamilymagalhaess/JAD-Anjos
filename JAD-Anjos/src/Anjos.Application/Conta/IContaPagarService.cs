using Anjos.Domain.Dto;
using Anjos.Domain.Entities;
using System.Threading.Tasks;

namespace Anjos.Application.Services;

public interface IContaPagarService
{
    Task<ContaPagar> ObterByIdAsync(int id);
    Task<PaginacaoResultadoDto> ObterPaginadoComTotalAsync(PaginacaoDto dto);
    Task<ContaPagar> AdicionarContaPagarAsync(ContaPagarDto contaPagarDto);
    Task<ContaPagar> AtualizarContaPagarAsync(ContaPagarDto contaPagarDto);
    Task DeletarContaPagarAsync(int id);
}

using Anjos.Domain.Dto;
using Anjos.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Anjos.Application.Services;

public interface IContaReceberService
{
    Task<ContaReceber> ObterByIdAsync(int id);
    Task<PaginacaoResultadoDto> ObterPaginadoComTotalAsync(PaginacaoDto dto);
    Task<ContaReceber> AdicionarContaReceberAsync(ContaReceberDto contaReceberDto);
    Task<ContaReceber> AtualizarContaReceberAsync(ContaReceberDto contaReceberDto);
    Task DeletarContaReceberAsync(int id);
}

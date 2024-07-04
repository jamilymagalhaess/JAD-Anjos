using System.Threading.Tasks;
using Anjos.Domain.Dto;
using Anjos.Domain.Entities;

namespace Anjos.Application.Services;

public interface IVendaService
{
    Task<Venda> ObterByIdAsync(int id);
    Task<PaginacaoResultadoDto> ObterPaginadoComTotalAsync(PaginacaoDto dto);
    Task<Venda> AdicionarVendaAsync(VendaDto vendaDto);
    Task<Venda> AtualizarVendaAsync(VendaDto vendaDto);
    Task DeletarVendaAsync(int id);
}

using Anjos.Domain.Dto;
using Anjos.Domain.Entities;
using System.Threading.Tasks;

namespace Anjos.Application.Interfaces;

public interface IProdutoService
{
    Task<Produto?> ObterByIdAsync(int id);
    Task<PaginacaoResultadoDto> ObterPaginadoComTotalAsync(PaginacaoDto dto);
    Task<Produto> AdicionarProdutoAsync(Produto dto);
    Task<Produto> AtualizarProdutoAsync(Produto produto);
    Task DeletarProdutoAsync(int id);
}

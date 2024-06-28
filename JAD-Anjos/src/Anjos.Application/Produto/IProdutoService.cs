using Anjos.Domain.Dto;
using Anjos.Domain.Entities;
using System.Threading.Tasks;

namespace Anjos.Application.Interfaces;

public interface IProdutoService
{
    Task<Produto?> ObterByIdAsync(int id);
    Task<PaginacaoResultado> ObterPaginadoComTotalAsync(Paginacao dto);
    Task<Produto> AdicionarProdutoAsync(Produto dto);
}

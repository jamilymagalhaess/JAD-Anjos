using Anjos.Database.Repositories.Base;
using Anjos.Domain.Dto;
using ProdutoEntity = Anjos.Domain.Entities.Produto;

namespace Anjos.Database.Repositories;
public interface IProdutoRepository : IRepository<ProdutoEntity>
{
    Task<ProdutoEntity?> ObterByIdAsync(int id);
    Task<int> ObterTotalProdutosAsync(int? filter);
    Task Atualizar(ProdutoEntity produto);
    Task Deletar(ProdutoEntity produto);
    Task<IEnumerable<ProdutoEntity>> ObterPaginadoAsync(PaginacaoDto dto);
}

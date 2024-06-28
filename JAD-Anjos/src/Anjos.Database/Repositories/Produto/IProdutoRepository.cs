using Anjos.Database.Repositories.Base;
using Anjos.Domain.Dto;

namespace Anjos.Database.Repositories.Produto;

public interface IProdutoRepository : IRepository<Domain.Entities.Produto>
{
    Task<Domain.Entities.Produto?> ObterByIdAsync(int id);
    Task<int> ObterTotalProdutosAsync(int? filter);
    Task<IEnumerable<Domain.Entities.Produto>> ObterPaginadoAsync(Paginacao dto);
}

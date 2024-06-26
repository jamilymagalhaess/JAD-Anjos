using Anjos.Domain.Dto;
using Anjos.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Anjos.Database.Repositories.Produto;

public interface IProdutoRepository : IRepository<Domain.Entities.Produto>
{
    Task<Domain.Entities.Produto?> ObterByIdAsync(int id);
    Task<int> ObterTotalProdutosAsync(int? filter);
    Task<IEnumerable<Domain.Entities.Produto>> ObterPaginadoAsync(Paginacao dto);
    IQueryable<Domain.Entities.Produto> AplicarOrdenacao(IQueryable<Domain.Entities.Produto> query, string orderBy, string orderDirection);
}

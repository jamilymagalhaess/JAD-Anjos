using Anjos.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Anjos.Database.Repositories.Produto
{
    public interface IProdutoRepository : IRepository<Domain.Entities.Produto>
    {
        Task<IEnumerable<Domain.Entities.Produto>> ObterTodosAsync();
        Task<Domain.Entities.Produto?> ObterByIdAsync(int id);
    }
}

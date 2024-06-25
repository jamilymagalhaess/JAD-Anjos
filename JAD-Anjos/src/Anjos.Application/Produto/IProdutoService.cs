using Anjos.Domain.Entities;
using System.Threading.Tasks;

namespace Anjos.Application.Interfaces
{
    public interface IProdutoService
    {
        Task<Produto?> ObterByIdAsync(int id);
    }
}

using Anjos.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Anjos.Application.Services;

public interface IEntradaProdutoService
{
    Task<EntradaProduto> ObterByIdAsync(int id);
    Task<IEnumerable<EntradaProduto>> ObterPorEntradaIdAsync(int entradaId);
    Task AdicionarEntradaProdutoAsync(EntradaProduto entradaProduto);
    Task AtualizarEntradaProdutoAsync(EntradaProduto entradaProduto);
    Task DeletarEntradaProdutoAsync(int id);
}

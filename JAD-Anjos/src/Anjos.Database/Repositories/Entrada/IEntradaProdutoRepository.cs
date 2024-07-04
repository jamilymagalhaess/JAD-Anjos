using Anjos.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Anjos.Database.Repositories;

public interface IEntradaProdutoRepository
{
    Task<EntradaProduto> ObterByIdAsync(int id);
    Task<IEnumerable<EntradaProduto>> ObterPorEntradaIdAsync(int entradaId);
    Task Adicionar(EntradaProduto entradaProduto);
    Task Atualizar(EntradaProduto entradaProduto);
    Task Deletar(EntradaProduto entradaProduto);
}

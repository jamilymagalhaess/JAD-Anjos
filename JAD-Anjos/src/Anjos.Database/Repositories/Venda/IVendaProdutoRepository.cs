using Anjos.Domain.Entities;
using Anjos.Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;
using Anjos.Database.Repositories.Base;

namespace Anjos.Database.Repositories;

public interface IVendaProdutoRepository : IRepository<VendaProduto>
{
    Task<VendaProduto> ObterByIdAsync(int id);
    Task<IEnumerable<VendaProduto>> ObterPorVendaIdAsync(int vendaId);
    Task Adicionar(VendaProduto vendaProduto);
    Task Atualizar(VendaProduto vendaProduto);
    Task Deletar(VendaProduto vendaProduto);
}

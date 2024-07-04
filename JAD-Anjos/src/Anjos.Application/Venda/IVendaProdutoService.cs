using Anjos.Domain.Dto;
using Anjos.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Anjos.Application.Services;

public interface IVendaProdutoService
{
    Task<VendaProduto> ObterByIdAsync(int id);
    Task<IEnumerable<VendaProduto>> ObterPorVendaIdAsync(int vendaId);
    Task AdicionarVendaProdutoAsync(VendaProdutoDto vendaProdutoDto);
    Task AtualizarVendaProdutoAsync(VendaProdutoDto vendaProdutoDto);
    Task DeletarVendaProdutoAsync(int id);
}


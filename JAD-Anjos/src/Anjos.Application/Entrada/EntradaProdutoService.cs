using Anjos.Database.Repositories;
using Anjos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Anjos.Application.Services;

public class EntradaProdutoService : IEntradaProdutoService
{
    private readonly IEntradaProdutoRepository _entradaProdutoRepository;

    public EntradaProdutoService(IEntradaProdutoRepository entradaProdutoRepository)
    {
        _entradaProdutoRepository = entradaProdutoRepository;
    }

    public async Task<EntradaProduto> ObterByIdAsync(int id)
    {
        var entradaProduto = await _entradaProdutoRepository.ObterByIdAsync(id);
        if (entradaProduto == null)
            throw new KeyNotFoundException($"EntradaProduto com ID {id} não encontrado.");
        return entradaProduto;
    }

    public async Task<IEnumerable<EntradaProduto>> ObterPorEntradaIdAsync(int entradaId)
    {
        return await _entradaProdutoRepository.ObterPorEntradaIdAsync(entradaId);
    }

    public async Task AdicionarEntradaProdutoAsync(EntradaProduto entradaProduto)
    {
        await _entradaProdutoRepository.Adicionar(entradaProduto);
    }

    public async Task AtualizarEntradaProdutoAsync(EntradaProduto entradaProduto)
    {
        await _entradaProdutoRepository.Atualizar(entradaProduto);
    }

    public async Task DeletarEntradaProdutoAsync(int id)
    {
        var entradaProduto = await _entradaProdutoRepository.ObterByIdAsync(id);
        if (entradaProduto == null)
            throw new KeyNotFoundException($"EntradaProduto com ID {id} não encontrado.");

        await _entradaProdutoRepository.Deletar(entradaProduto);
    }
}

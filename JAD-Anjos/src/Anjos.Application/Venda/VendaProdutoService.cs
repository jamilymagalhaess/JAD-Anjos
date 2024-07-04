using Anjos.Domain.Dto;
using Anjos.Domain.Entities;
using Anjos.Database.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Anjos.Application.Services;

public class VendaProdutoService : IVendaProdutoService
{
    private readonly IVendaProdutoRepository _vendaProdutoRepository;

    public VendaProdutoService(IVendaProdutoRepository vendaProdutoRepository)
    {
        _vendaProdutoRepository = vendaProdutoRepository;
    }

    public async Task<VendaProduto> ObterByIdAsync(int id)
    {
        var vendaProduto = await _vendaProdutoRepository.ObterByIdAsync(id);
        if (vendaProduto == null)
            throw new KeyNotFoundException($"VendaProduto com ID {id} não encontrado.");
        return vendaProduto;
    }

    public async Task<IEnumerable<VendaProduto>> ObterPorVendaIdAsync(int vendaId)
    {
        return await _vendaProdutoRepository.ObterPorVendaIdAsync(vendaId);
    }

    public async Task AdicionarVendaProdutoAsync(VendaProdutoDto vendaProdutoDto)
    {
        var vendaProduto = new VendaProduto
        {
            Valor = vendaProdutoDto.Valor,
            Quantidade = vendaProdutoDto.Quantidade,
            VendaId = vendaProdutoDto.VendaId,
            ProdutoId = vendaProdutoDto.ProdutoId
        };

        await _vendaProdutoRepository.Adicionar(vendaProduto);
    }

    public async Task AtualizarVendaProdutoAsync(VendaProdutoDto vendaProdutoDto)
    {
        var vendaProduto = new VendaProduto
        {
            Id = vendaProdutoDto.Id,
            Valor = vendaProdutoDto.Valor,
            Quantidade = vendaProdutoDto.Quantidade,
            VendaId = vendaProdutoDto.VendaId,
            ProdutoId = vendaProdutoDto.ProdutoId
        };

        await _vendaProdutoRepository.Atualizar(vendaProduto);
    }

    public async Task DeletarVendaProdutoAsync(int id)
    {
        var vendaProduto = await _vendaProdutoRepository.ObterByIdAsync(id);
        if (vendaProduto == null)
            throw new KeyNotFoundException($"VendaProduto com ID {id} não encontrado.");

        await _vendaProdutoRepository.Deletar(vendaProduto);
    }
}

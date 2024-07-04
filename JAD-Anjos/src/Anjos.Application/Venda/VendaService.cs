using Anjos.Domain.Dto;
using Anjos.Domain.Entities;
using Anjos.Database.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Anjos.Application.Services;

public class VendaService : IVendaService
{
    private readonly IVendaRepository _vendaRepository;

    public VendaService(IVendaRepository vendaRepository)
    {
        _vendaRepository = vendaRepository;
    }

    public async Task<Venda> ObterByIdAsync(int id)
    {
        var venda = await _vendaRepository.ObterByIdAsync(id);
        if (venda == null)
            throw new KeyNotFoundException($"Venda com ID {id} não encontrada.");
        return venda;
    }

    public async Task<PaginacaoResultadoDto> ObterPaginadoComTotalAsync(PaginacaoDto dto)
    {
        if (dto.Pagina <= 0) throw new ArgumentException("O número da página não pode ser vazio.");
        if (!string.IsNullOrEmpty(dto.DirecaoDaOrdenacao) && (dto.DirecaoDaOrdenacao.ToLower() != "asc" && dto.DirecaoDaOrdenacao.ToLower() != "desc")) throw new ArgumentException("Direção de ordenação inválida. Use 'asc' ou 'desc'.");
        if (string.IsNullOrEmpty(dto.DirecaoDaOrdenacao)) dto.DirecaoDaOrdenacao = "asc";
        if (string.IsNullOrEmpty(dto.Ordenacao)) dto.Ordenacao = "DataVenda";
        if (dto.Itens <= 0) dto.Itens = 10;

        var vendas = await _vendaRepository.ObterPaginadoAsync(dto);
        var total = await _vendaRepository.ObterTotalVendasAsync(dto.Filtro);
        int totalPagina = (int)Math.Ceiling((double)total / dto.Itens);

        var result = new PaginacaoResultadoDto
        {
            Total = total,
            Pagina = dto.Pagina,
            Itens = dto.Itens,
            TotalPagina = totalPagina,
            Vendas = vendas.ToList()
        };
        return result;
    }

    public async Task<Venda> AdicionarVendaAsync(VendaDto vendaDto)
    {
        if (vendaDto.Valor <= 0) throw new ArgumentException("O valor da venda deve ser maior que zero.");
        if (vendaDto.DataVenda == default) throw new ArgumentException("A data da venda é obrigatória.");

        var venda = new Venda
        {
            Valor = vendaDto.Valor,
            DataVenda = vendaDto.DataVenda,
            DataInclusao = vendaDto.DataInclusao,
            FormaPagamento = vendaDto.FormaPagamento
        };

        var vendaAdicionada = await _vendaRepository.Adicionar(venda);

        if (vendaAdicionada == null) throw new Exception("Erro ao adicionar a venda.");
        return vendaAdicionada;
    }

    public async Task<Venda> AtualizarVendaAsync(VendaDto vendaDto)
    {
        if (vendaDto == null) throw new ArgumentException("Venda não pode ser nula.");
        if (vendaDto.Id <= 0) throw new ArgumentException("ID da venda é inválido.");
        if (vendaDto.Valor <= 0) throw new ArgumentException("O valor da venda deve ser maior que zero.");
        if (vendaDto.DataVenda == default) throw new ArgumentException("A data da venda é obrigatória.");

        var venda = new Venda
        {
            Id = vendaDto.Id,
            Valor = vendaDto.Valor,
            DataVenda = vendaDto.DataVenda,
            DataInclusao = vendaDto.DataInclusao,
            FormaPagamento = vendaDto.FormaPagamento
        };

        await _vendaRepository.Atualizar(venda);

        var vendaAtualizada = await _vendaRepository.ObterByIdAsync(venda.Id);
        if (vendaAtualizada == null) throw new Exception("Erro ao atualizar a venda.");
        return vendaAtualizada;
    }

    public async Task DeletarVendaAsync(int id)
    {
        var venda = await _vendaRepository.ObterByIdAsync(id);
        if (venda == null) throw new KeyNotFoundException($"Venda com ID {id} não encontrada.");

        await _vendaRepository.Deletar(venda);
    }
}

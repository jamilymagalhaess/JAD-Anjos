using Anjos.Domain.Dto;
using Anjos.Domain.Entities;
using Anjos.Database.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Anjos.Application.Services;

public class ContaPagarService : IContaPagarService
{
    private readonly IContaPagarRepository _contaPagarRepository;

    public ContaPagarService(IContaPagarRepository contaPagarRepository)
    {
        _contaPagarRepository = contaPagarRepository;
    }

    public async Task<ContaPagar> ObterByIdAsync(int id)
    {
        var contaPagar = await _contaPagarRepository.ObterByIdAsync(id);
        if (contaPagar == null)
            throw new KeyNotFoundException($"ContaPagar com ID {id} não encontrada.");
        return contaPagar;
    }

    public async Task<PaginacaoResultadoDto> ObterPaginadoComTotalAsync(PaginacaoDto dto)
    {
        if (dto.Pagina <= 0) throw new ArgumentException("O número da página não pode ser vazio.");
        if (!string.IsNullOrEmpty(dto.DirecaoDaOrdenacao) && (dto.DirecaoDaOrdenacao.ToLower() != "asc" && dto.DirecaoDaOrdenacao.ToLower() != "desc")) throw new ArgumentException("Direção de ordenação inválida. Use 'asc' ou 'desc'.");
        if (string.IsNullOrEmpty(dto.DirecaoDaOrdenacao)) dto.DirecaoDaOrdenacao = "asc";
        if (string.IsNullOrEmpty(dto.Ordenacao)) dto.Ordenacao = "DataVenda";
        if (dto.Itens <= 0) dto.Itens = 10;

        var contasPagar = await _contaPagarRepository.ObterPaginadoAsync(dto);
        var total = await _contaPagarRepository.ObterTotalContasPagarAsync(dto.Filtro);
        int totalPagina = (int)Math.Ceiling((double)total / dto.Itens);

        var result = new PaginacaoResultadoDto
        {
            Total = total,
            Pagina = dto.Pagina,
            Itens = dto.Itens,
            TotalPagina = totalPagina,
            ContasPagar = contasPagar.ToList()
        };
        return result;
    }

    public async Task<ContaPagar> AdicionarContaPagarAsync(ContaPagarDto contaPagarDto)
    {
        if (contaPagarDto.Valor <= 0) throw new ArgumentException("O valor da conta a pagar deve ser maior que zero.");

        var contaPagar = new ContaPagar
        {
            Valor = contaPagarDto.Valor,
            QuantidadeParcelas = contaPagarDto.QuantidadeParcelas,
            EntradaId = contaPagarDto.EntradaId
        };

        var contaPagarAdicionada = await _contaPagarRepository.Adicionar(contaPagar);

        if (contaPagarAdicionada == null) throw new Exception("Erro ao adicionar a conta a pagar.");
        return contaPagarAdicionada;
    }

    public async Task<ContaPagar> AtualizarContaPagarAsync(ContaPagarDto contaPagarDto)
    {
        if (contaPagarDto == null) throw new ArgumentException("ContaPagar não pode ser nula.");
        if (contaPagarDto.Id <= 0) throw new ArgumentException("ID da conta a pagar é inválido.");
        if (contaPagarDto.Valor <= 0) throw new ArgumentException("O valor da conta a pagar deve ser maior que zero.");

        var contaPagar = new ContaPagar
        {
            Id = contaPagarDto.Id,
            Valor = contaPagarDto.Valor,
            QuantidadeParcelas = contaPagarDto.QuantidadeParcelas,
            EntradaId = contaPagarDto.EntradaId
        };

        await _contaPagarRepository.Atualizar(contaPagar);

        var contaPagarAtualizada = await _contaPagarRepository.ObterByIdAsync(contaPagar.Id);
        if (contaPagarAtualizada == null) throw new Exception("Erro ao atualizar a conta a pagar.");
        return contaPagarAtualizada;
    }

    public async Task DeletarContaPagarAsync(int id)
    {
        var contaPagar = await _contaPagarRepository.ObterByIdAsync(id);
        if (contaPagar == null) throw new KeyNotFoundException($"ContaPagar com ID {id} não encontrada.");

        await _contaPagarRepository.Deletar(contaPagar);
    }
}

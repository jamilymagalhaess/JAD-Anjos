using Anjos.Domain.Dto;
using Anjos.Domain.Entities;
using Anjos.Database.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Anjos.Application.Services;

public class ParcelaService : IParcelaService
{
    private readonly IParcelaRepository _parcelaRepository;

    public ParcelaService(IParcelaRepository parcelaRepository)
    {
        _parcelaRepository = parcelaRepository;
    }

    public async Task<Parcela> ObterByIdAsync(int id)
    {
        var parcela = await _parcelaRepository.ObterByIdAsync(id);
        if (parcela == null)
            throw new KeyNotFoundException($"Parcela com ID {id} não encontrada.");
        return parcela;
    }

    public async Task<PaginacaoResultadoDto> ObterPaginadoComTotalAsync(PaginacaoDto dto)
    {
        if (dto.Pagina <= 0) throw new ArgumentException("O número da página não pode ser vazio.");
        if (!string.IsNullOrEmpty(dto.DirecaoDaOrdenacao) && (dto.DirecaoDaOrdenacao.ToLower() != "asc" && dto.DirecaoDaOrdenacao.ToLower() != "desc")) throw new ArgumentException("Direção de ordenação inválida. Use 'asc' ou 'desc'.");
        if (string.IsNullOrEmpty(dto.DirecaoDaOrdenacao)) dto.DirecaoDaOrdenacao = "asc";
        if (string.IsNullOrEmpty(dto.Ordenacao)) dto.Ordenacao = "DataVencimento";
        if (dto.Itens <= 0) dto.Itens = 10;

        var parcelas = await _parcelaRepository.ObterPaginadoAsync(dto);
        var total = await _parcelaRepository.ObterTotalParcelasAsync(dto.Filtro);
        int totalPagina = (int)Math.Ceiling((double)total / dto.Itens);

        var result = new PaginacaoResultadoDto
        {
            Total = total,
            Pagina = dto.Pagina,
            Itens = dto.Itens,
            TotalPagina = totalPagina,
            Parcelas = parcelas.ToList()
        };
        return result;
    }

    public async Task<Parcela> AdicionarParcelaAsync(ParcelaDto parcelaDto)
    {
        if (parcelaDto.Valor <= 0) throw new ArgumentException("O valor da parcela deve ser maior que zero.");
        if (parcelaDto.DataVencimento == default) throw new ArgumentException("A data de vencimento é obrigatória.");

        var parcela = new Parcela
        {
            Tipo = parcelaDto.Tipo,
            Numero = parcelaDto.Numero,
            Valor = parcelaDto.Valor,
            Juros = parcelaDto.Juros,
            DataVencimento = parcelaDto.DataVencimento,
            ContaPagarId = parcelaDto.ContaPagarId,
            ContaReceberId = parcelaDto.ContaReceberId
        };

        var parcelaAdicionada = await _parcelaRepository.Adicionar(parcela);

        if (parcelaAdicionada == null) throw new Exception("Erro ao adicionar a parcela.");
        return parcelaAdicionada;
    }

    public async Task<Parcela> AtualizarParcelaAsync(ParcelaDto parcelaDto)
    {
        if (parcelaDto == null) throw new ArgumentException("Parcela não pode ser nula.");
        if (parcelaDto.Id <= 0) throw new ArgumentException("ID da parcela é inválido.");
        if (parcelaDto.Valor <= 0) throw new ArgumentException("O valor da parcela deve ser maior que zero.");
        if (parcelaDto.DataVencimento == default) throw new ArgumentException("A data de vencimento é obrigatória.");

        var parcela = new Parcela
        {
            Id = parcelaDto.Id,
            Tipo = parcelaDto.Tipo,
            Numero = parcelaDto.Numero,
            Valor = parcelaDto.Valor,
            Juros = parcelaDto.Juros,
            DataVencimento = parcelaDto.DataVencimento,
            ContaPagarId = parcelaDto.ContaPagarId,
            ContaReceberId = parcelaDto.ContaReceberId
        };

        await _parcelaRepository.Atualizar(parcela);

        var parcelaAtualizada = await _parcelaRepository.ObterByIdAsync(parcela.Id);
        if (parcelaAtualizada == null) throw new Exception("Erro ao atualizar a parcela.");
        return parcelaAtualizada;
    }

    public async Task DeletarParcelaAsync(int id)
    {
        var parcela = await _parcelaRepository.ObterByIdAsync(id);
        if (parcela == null) throw new KeyNotFoundException($"Parcela com ID {id} não encontrada.");

        await _parcelaRepository.Deletar(parcela);
    }
}

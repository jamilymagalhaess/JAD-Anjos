using Anjos.Domain.Dto;
using Anjos.Domain.Entities;
using Anjos.Database.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Anjos.Application.Services;

public class ContaReceberService : IContaReceberService
{
    private readonly IContaReceberRepository _contaReceberRepository;

    public ContaReceberService(IContaReceberRepository contaReceberRepository)
    {
        _contaReceberRepository = contaReceberRepository;
    }

    public async Task<ContaReceber> ObterByIdAsync(int id)
    {
        var contaReceber = await _contaReceberRepository.ObterByIdAsync(id);
        if (contaReceber == null)
            throw new KeyNotFoundException($"ContaReceber com ID {id} não encontrada.");
        return contaReceber;
    }

    public async Task<PaginacaoResultadoDto> ObterPaginadoComTotalAsync(PaginacaoDto dto)
    {
        if (dto.Pagina <= 0) throw new ArgumentException("O número da página não pode ser vazio.");
        if (!string.IsNullOrEmpty(dto.DirecaoDaOrdenacao) && (dto.DirecaoDaOrdenacao.ToLower() != "asc" && dto.DirecaoDaOrdenacao.ToLower() != "desc")) throw new ArgumentException("Direção de ordenação inválida. Use 'asc' ou 'desc'.");
        if (string.IsNullOrEmpty(dto.DirecaoDaOrdenacao)) dto.DirecaoDaOrdenacao = "asc";
        if (string.IsNullOrEmpty(dto.Ordenacao)) dto.Ordenacao = "Valor";
        if (dto.Itens <= 0) dto.Itens = 10;

        var contasReceber = await _contaReceberRepository.ObterPaginadoAsync(dto);
        var total = await _contaReceberRepository.ObterTotalContasReceberAsync(dto.Filtro);
        int totalPagina = (int)Math.Ceiling((double)total / dto.Itens);

        var result = new PaginacaoResultadoDto
        {
            Total = total,
            Pagina = dto.Pagina,
            Itens = dto.Itens,
            TotalPagina = totalPagina,
            ContasReceber = contasReceber.ToList()
        };
        return result;
    }

    public async Task<ContaReceber> AdicionarContaReceberAsync(ContaReceberDto contaReceberDto)
    {
        if (contaReceberDto.Valor <= 0) throw new ArgumentException("O valor da conta a receber deve ser maior que zero.");
        if (contaReceberDto.QuantidadeParcelas <= 0) throw new ArgumentException("A quantidade de parcelas deve ser maior que zero.");

        var contaReceber = new ContaReceber
        {
            Valor = contaReceberDto.Valor,
            QuantidadeParcelas = contaReceberDto.QuantidadeParcelas,
            VendaId = contaReceberDto.VendaId
        };

        var contaReceberAdicionada = await _contaReceberRepository.Adicionar(contaReceber);

        if (contaReceberAdicionada == null) throw new Exception("Erro ao adicionar a conta a receber.");
        return contaReceberAdicionada;
    }

    public async Task<ContaReceber> AtualizarContaReceberAsync(ContaReceberDto contaReceberDto)
    {
        if (contaReceberDto == null) throw new ArgumentException("Conta a receber não pode ser nula.");
        if (contaReceberDto.Id <= 0) throw new ArgumentException("ID da conta a receber é inválido.");
        if (contaReceberDto.Valor <= 0) throw new ArgumentException("O valor da conta a receber deve ser maior que zero.");
        if (contaReceberDto.QuantidadeParcelas <= 0) throw new ArgumentException("A quantidade de parcelas deve ser maior que zero.");

        var contaReceber = new ContaReceber
        {
            Id = contaReceberDto.Id,
            Valor = contaReceberDto.Valor,
            QuantidadeParcelas = contaReceberDto.QuantidadeParcelas,
            VendaId = contaReceberDto.VendaId
        };

        await _contaReceberRepository.Atualizar(contaReceber);

        var contaReceberAtualizada = await _contaReceberRepository.ObterByIdAsync(contaReceber.Id);
        if (contaReceberAtualizada == null) throw new Exception("Erro ao atualizar a conta a receber.");
        return contaReceberAtualizada;
    }

    public async Task DeletarContaReceberAsync(int id)
    {
        var contaReceber = await _contaReceberRepository.ObterByIdAsync(id);
        if (contaReceber == null) throw new KeyNotFoundException($"ContaReceber com ID {id} não encontrada.");

        await _contaReceberRepository.Deletar(contaReceber);
    }
}

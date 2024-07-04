using Anjos.Domain.Entities;
using Anjos.Domain.Dto;
using Anjos.Database.Repositories;

namespace Anjos.Application.Services;

public class EntradaService : IEntradaService
{
    private readonly IEntradaRepository _entradaRepository;

    public EntradaService(IEntradaRepository entradaRepository)
    {
        _entradaRepository = entradaRepository;
    }

    public async Task<Entrada> ObterByIdAsync(int id)
    {
        var entrada = await _entradaRepository.ObterByIdAsync(id);
        if (entrada == null)
            throw new KeyNotFoundException($"Entrada com ID {id} não encontrada.");
        return entrada;
    }

    public async Task<PaginacaoResultadoDto> ObterPaginadoComTotalAsync(PaginacaoDto dto)
    {
        if (dto.Pagina <= 0) throw new ArgumentException("O número da pagina não pode ser vazio.");
        if (!string.IsNullOrEmpty(dto.DirecaoDaOrdenacao) && (dto.DirecaoDaOrdenacao.ToLower() != "asc" && dto.DirecaoDaOrdenacao.ToLower() != "desc")) throw new ArgumentException("Direção de ordenação inválida. Use 'asc' ou 'desc'.");
        if (string.IsNullOrEmpty(dto.DirecaoDaOrdenacao)) dto.DirecaoDaOrdenacao = "asc";
        if (string.IsNullOrEmpty(dto.Ordenacao)) dto.Ordenacao = "Id";
        if (dto.Itens <= 0) dto.Itens = 10;

        var entradas = await _entradaRepository.ObterPaginadoAsync(dto);
        var total = await _entradaRepository.ObterTotalEntradasAsync(dto.Filtro);
        int totalPagina = (int)Math.Ceiling((double)total / dto.Itens);

        var result = new PaginacaoResultadoDto
        {
            Total = total,
            Pagina = dto.Pagina,
            Itens = dto.Itens,
            TotalPagina = totalPagina,
            Entradas = entradas.ToList()
        };
        return result;
    }

    public async Task<Entrada> AdicionarEntradaAsync(EntradaDto entradaDto)
    {
        if (entradaDto.Valor <= 0) throw new ArgumentException("O valor da entrada deve ser positivo.");

        var entrada = new Entrada
        {
            Valor = entradaDto.Valor
        };

        var entradaAdicionada = await _entradaRepository.Adicionar(entrada);

        if (entradaAdicionada == null) throw new Exception("Erro ao adicionar a entrada.");
        return entradaAdicionada;
    }

    public async Task<Entrada> AtualizarEntradaAsync(EntradaDto entradaDto)
    {
        if (entradaDto == null) throw new ArgumentException("Entrada não pode ser nula.");
        if (entradaDto.Id <= 0) throw new ArgumentException("ID da entrada é inválido.");
        if (entradaDto.Valor <= 0) throw new ArgumentException("O valor da entrada deve ser positivo.");

        var entrada = new Entrada
        {
            Id = entradaDto.Id,
            Valor = entradaDto.Valor,
        };

        await _entradaRepository.Atualizar(entrada);

        var entradaAtualizada = await _entradaRepository.ObterByIdAsync(entrada.Id);
        if (entradaAtualizada == null) throw new Exception("Erro ao atualizar a entrada.");
        return entradaAtualizada;
    }

    public async Task DeletarEntradaAsync(int id)
    {
        var entrada = await _entradaRepository.ObterByIdAsync(id);
        if (entrada == null) throw new KeyNotFoundException($"Entrada com ID {id} não encontrada.");

        await _entradaRepository.Deletar(entrada);
    }
}

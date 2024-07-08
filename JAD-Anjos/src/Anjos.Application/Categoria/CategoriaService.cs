using Anjos.Domain.Entities;
using Anjos.Domain.Dto;

using Anjos.Application.Interfaces;

namespace Anjos.Application.Services;
public class CategoriaService : ICategoriaService
{
    private readonly ICategoriaRepository _categoriaRepository;

    public CategoriaService(ICategoriaRepository categoriaRepository)
    {
        _categoriaRepository = categoriaRepository;
    }

    public async Task<Categoria> ObterByIdAsync(int id)
    {
        var categoria = await _categoriaRepository.ObterByIdAsync(id);
        if (categoria == null)
            throw new KeyNotFoundException($"Categoria com ID {id} não encontrada.");
        return categoria;
    }

    public async Task<PaginacaoResultadoDto> ObterPaginadoComTotalAsync(PaginacaoDto dto)
    {
        if (dto.Pagina <= 0) throw new ArgumentException("O número da pagina não pode ser vazio.");
        if (!string.IsNullOrEmpty(dto.DirecaoDaOrdenacao) && (dto.DirecaoDaOrdenacao.ToLower() != "asc" && dto.DirecaoDaOrdenacao.ToLower() != "desc")) throw new ArgumentException("Direção de ordenação inválida. Use 'asc' ou 'desc'.");
        if (string.IsNullOrEmpty(dto.DirecaoDaOrdenacao)) dto.DirecaoDaOrdenacao = "asc";
        if (string.IsNullOrEmpty(dto.Ordenacao)) dto.Ordenacao = "Nome";
        if (dto.Itens <= 0) dto.Itens = 10;

        var categorias = await _categoriaRepository.ObterPaginadoAsync(dto);
        var total = await _categoriaRepository.ObterTotalCategoriasAsync(dto.Filtro);
        int totalPagina = (int)Math.Ceiling((double)total / dto.Itens);

        var result =  new PaginacaoResultadoDto
        {
            Total = total,
            Pagina = dto.Pagina,
            Itens = dto.Itens,
            TotalPagina = totalPagina,
            Categorias = categorias.ToList()
        };
        return result;
    }

    public async Task<Categoria> AdicionarCategoriaAsync(CategoriaDto categoriaDto)
    {
        if (string.IsNullOrEmpty(categoriaDto.Nome)) throw new ArgumentException("É necessário informar o nome do produto");
        if (string.IsNullOrEmpty(categoriaDto.Descricao)) throw new ArgumentException("É necessário informar a descrição do produto.");

        var categoria = new Categoria
        {
            Nome = categoriaDto.Nome,
            Descricao = categoriaDto.Descricao
        };

        var categoriaAdicionada = await _categoriaRepository.Adicionar(categoria);

        if (categoriaAdicionada == null) throw new Exception("Erro ao adicionar a categoria.");
        return categoriaAdicionada;
    }

    public async Task<Categoria> AtualizarCategoriaAsync(CategoriaDto categoriaDto)
    {
        if (categoriaDto == null) throw new ArgumentException("Categoria não pode ser nula.");
        if (categoriaDto.Id <= 0) throw new ArgumentException("ID da categoria é inválido.");
        if (string.IsNullOrWhiteSpace(categoriaDto.Nome)) throw new ArgumentException("Nome do produto é obrigatório.");
        if (string.IsNullOrWhiteSpace(categoriaDto.Descricao)) throw new ArgumentException("Descrição do produto é obrigatória.");

        var categoria = new Categoria
        {
            Nome = categoriaDto.Nome,
            Descricao = categoriaDto.Descricao
        };

        await _categoriaRepository.Atualizar(categoria);

        var categoriaAtualizada = await _categoriaRepository.ObterByIdAsync(categoria.Id);
        if (categoriaAtualizada == null) throw new Exception("Erro ao atualizar a categoria.");
        return categoriaAtualizada;
    }

    public async Task DeletarCategoriaAsync(int id)
    {
        var categoria = await _categoriaRepository.ObterByIdAsync(id);
        if (categoria == null) throw new KeyNotFoundException($"Categoria com ID {id} não encontrada.");

        await _categoriaRepository.Deletar(categoria);
    }
}

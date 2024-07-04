using Anjos.Application.Interfaces;
using Anjos.Domain.Entities;
using Anjos.Domain.Dto;

namespace Anjos.Application.Services;

public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoService(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<Produto?> ObterByIdAsync(int id)
    {
            var produto = await _produtoRepository.ObterByIdAsync(id);
            if (produto == null) throw new KeyNotFoundException($"Produto com ID {id} não encontrado.");

            return produto; 
    }

   public async Task<PaginacaoResultadoDto> ObterPaginadoComTotalAsync(PaginacaoDto dto)
    {
        if (dto.Pagina <= 0) throw new ArgumentException("O número da pagina não pode ser vazio.");
        if (!string.IsNullOrEmpty(dto.DirecaoDaOrdenacao) && (dto.DirecaoDaOrdenacao.ToLower() != "asc" && dto.DirecaoDaOrdenacao.ToLower() != "desc")) throw new ArgumentException("Direção de ordenação inválida. Use 'asc' ou 'desc'.");
        if (string.IsNullOrEmpty(dto.DirecaoDaOrdenacao)) dto.DirecaoDaOrdenacao = "asc";
        if (string.IsNullOrEmpty(dto.Ordenacao)) dto.Ordenacao = "Nome";
        if (dto.Itens <= 0) dto.Itens = 10;

        var produtos = await _produtoRepository.ObterPaginadoAsync(dto);
        var total = await _produtoRepository.ObterTotalProdutosAsync(dto.Filtro);
        int totalPagina = (int)Math.Ceiling((double)total / dto.Itens);

        var result = new PaginacaoResultadoDto
        {
            Total = total,
            Pagina = dto.Pagina,
            Itens = dto.Itens,
            TotalPagina = totalPagina,
            Produtos = produtos.ToList()
        };

        return result;
    }

    public async Task<Produto> AdicionarProdutoAsync(Produto dto)
    {
        if (string.IsNullOrEmpty(dto.Nome)) throw new ArgumentException("É necessário informar o nome do produto");
        if (string.IsNullOrEmpty(dto.Descricao)) throw new ArgumentException("É necessário informar a descrição do produto.");
        if (dto.CategoriaId <= 0) throw new ArgumentException("É necessário vincular o produto a uma categoria");

        var produtoAdicionado = await _produtoRepository.Adicionar(dto);

        if (produtoAdicionado == null) throw new Exception("Erro ao adicionar o produto.");
        
        return produtoAdicionado;
    }

    public async Task<Produto> AtualizarProdutoAsync(Produto produto)
    {
        if (produto == null) throw new ArgumentException("Produto não pode ser nulo.");
        if (produto.Id <= 0) throw new ArgumentException("ID do produto é inválido.");
        if (string.IsNullOrWhiteSpace(produto.Nome)) throw new ArgumentException("Nome do produto é obrigatório.");
        if (string.IsNullOrWhiteSpace(produto.Descricao)) throw new ArgumentException("Descrição do produto é obrigatória.");
        if (produto.Valor <= 0) throw new ArgumentException("Valor do produto deve ser maior que zero.");
        if (produto.Quantidade < 0) throw new ArgumentException("Quantidade do produto não pode ser negativa.");
        if (produto.CategoriaId <= 0) throw new ArgumentException("ID da categoria é inválido.");

        await _produtoRepository.Atualizar(produto);
        var produtoAtualizado = await _produtoRepository.ObterByIdAsync(produto.Id);

        if (produtoAtualizado == null) throw new Exception("Erro ao atualizar o produto.");

        return produtoAtualizado;
    }
    public async Task DeletarProdutoAsync(int id)
    {
        if (id <= 0) throw new ArgumentException("ID do produto é inválido.");
        
        var produto = await _produtoRepository.ObterByIdAsync(id);
        if (produto == null) throw new KeyNotFoundException($"Produto com ID {id} não encontrado.");

        await _produtoRepository.Deletar(produto);
    }
}




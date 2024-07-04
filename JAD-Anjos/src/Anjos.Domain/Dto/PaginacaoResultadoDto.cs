using Anjos.Domain.Entities;

namespace Anjos.Domain.Dto;

public class PaginacaoResultadoDto : PaginacaoDto 
{
    public int Total { get; set; }
    public int TotalPagina {  get; set; }
    public List<Produto>? Produtos { get; set; }
    public List<Categoria>? Categorias { get; set; }
    public List<Entrada>? Entradas { get; set; }
    public List<Venda> Vendas { get; set; }
    public List<VendaProduto> VendaProdutos { get; set; }
    public List<EntradaProduto> EntradaProdutos { get; set; }
    public List<Parcela> Parcelas { get; set; }
    public List<ContaPagar> ContasPagar { get; set; }
    public List<ContaReceber> ContasReceber { get; set; }

}

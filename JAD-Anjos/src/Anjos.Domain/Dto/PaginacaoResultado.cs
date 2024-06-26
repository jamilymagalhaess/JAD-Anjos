using Anjos.Domain.Entities;

namespace Anjos.Domain.Dto;

public class PaginacaoResultado 
{
    public int Pagina { get; set; }
    public int Itens { get; set; }
    public int Total { get; set; }
    public int TotalPagina {  get; set; }
    public List<Produto>? Produtos {  get; set; }


}

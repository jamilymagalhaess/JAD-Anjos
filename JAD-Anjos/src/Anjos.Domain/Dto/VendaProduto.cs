namespace Anjos.Domain.Dto;

public class VendaProdutoDto
{
    public int Id { get; set; }
    public decimal Valor { get; set; }
    public int Quantidade { get; set; }
    public int VendaId { get; set; }
    public int ProdutoId { get; set; }
}

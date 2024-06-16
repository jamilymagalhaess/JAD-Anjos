namespace Anjos.Model.Venda;

public class VendaProduto
{
    public int Id { get; set; }
    public int VendaId { get; set; }
    public int ProdutoId { get; set; }
    public decimal Valor { get; set; }
    public int Quantidade { get; set; }

}
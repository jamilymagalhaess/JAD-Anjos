namespace Anjos.Model.Entities.Venda;

public class VendaProdutoViewModel
{
    public int Id { get; set; }
    public int VendaId { get; set; }
    public int ProdutoId { get; set; }
    public decimal Valor { get; set; }
    public int Quantidade { get; set; }

}
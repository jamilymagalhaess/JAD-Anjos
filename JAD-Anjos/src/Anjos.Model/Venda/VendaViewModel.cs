namespace Anjos.Model.Entities.Venda;

public class VendaViewModel
{
    public int Id { get; set; }
    public decimal Valor { get; set; }
    public DateTime DataVenda { get; set; }
    public DateTime DataInclusao { get; set; }
    public string FormaPagamento { get; set; }

}

namespace Anjos.Model.Entities;

public class Venda
{
    public int Id { get; set; }
    public decimal Valor { get; set; }
    public DateTime DataVenda { get; set; }
    public DateTime DataInclusao { get; set; }
    public string FormaPagamento { get; set; }

}

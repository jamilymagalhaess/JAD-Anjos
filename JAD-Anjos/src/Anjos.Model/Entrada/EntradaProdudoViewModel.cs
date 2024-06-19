namespace Anjos.Model.Entities.Entrada;

public class EntradaProdutoViewModel
{
    public int Id { get; set; }
    public int EntradaId { get; set; }
    public int ProdutoId { get; set; }
    public int Quantidade { get; set; }
    public decimal Valor { get; set; }
    public DateTime DataEntrada { get; set; }
    public DateTime DataInclusao { get; set; }

}
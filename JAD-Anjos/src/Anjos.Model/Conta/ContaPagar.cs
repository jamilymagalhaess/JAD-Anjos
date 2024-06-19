namespace Anjos.Model.Entities;

public class ContaPagar
{
    public int Id { get; set; }
    public int EntradaId { get; set; }
    public decimal Valor { get; set; }
    public int QuantidadeParcelas { get; set; }

}

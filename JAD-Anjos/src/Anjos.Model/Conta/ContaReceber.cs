namespace Anjos.Model.Entities;
public class ContaReceber
{
    public int Id { get; set; }
    public int VendaId { get; set; }
    public int QuantidadeParcelas { get; set; }
    public decimal Valor { get; set; }

}
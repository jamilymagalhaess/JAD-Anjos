namespace Anjos.Model.Entities.Conta;
public class ContaReceberViewModel
{
    public int Id { get; set; }
    public int VendaId { get; set; }
    public int QuantidadeParcelas { get; set; }
    public decimal Valor { get; set; }

}
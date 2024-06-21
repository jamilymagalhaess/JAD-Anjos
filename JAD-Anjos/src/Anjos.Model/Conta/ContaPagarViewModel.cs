namespace Anjos.Model.Conta;

public class ContaPagarViewModel
{
    public int Id { get; set; }
    public int EntradaId { get; set; }
    public decimal Valor { get; set; }
    public int QuantidadeParcelas { get; set; }

}

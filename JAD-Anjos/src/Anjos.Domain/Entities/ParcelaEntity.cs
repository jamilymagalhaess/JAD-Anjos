using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anjos.Domain.Entities;

public class ParcelaEntity
{
    public ParcelaEntity()
    {
        
    }

    [Key]
    public int Id { get; set; }
    public int Tipo { get; set; }
    public int Numero { get; set; }
    public decimal Valor { get; set; }
    public decimal Juros { get; set; }
    public int ContaPagarId { get; set; }
    public DateTime DataVencimento { get; set; }
    public int ContaReceberId { get; set; }

    [ForeignKey("ContaPagarId")]
    public virtual ContaPagarEntity ContaPagar { get; set; }
    [ForeignKey("ContaReceberId")]
    public virtual ContaReceberEntity ContaReceber { get; set; }

}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anjos.Domain.Entities;

public class ContaPagarEntity
{
    public ContaPagarEntity()
    {
        
    }

    [Key]
    public int Id { get; set; }
    public int EntradaId { get; set; }
    public decimal Valor { get; set; }
    public int QuantidadeParcelas { get; set; }

    [ForeignKey("EntradaId")]
    public virtual EntradaEntity Entrada { get; set; }
    public virtual ICollection<ParcelaEntity> Parcela { get; set; }
}


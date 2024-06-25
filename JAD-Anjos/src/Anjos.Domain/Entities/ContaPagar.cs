using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anjos.Domain.Entities;

public class ContaPagar
{

    [Key]
    public int Id { get; set; }
    public decimal Valor { get; set; }
    public int QuantidadeParcelas { get; set; }
    public int EntradaId { get; set; }

    [ForeignKey("EntradaId")]
    public virtual Entrada? Entrada { get; set; }
    public virtual ICollection<Parcela?> Parcela { get; set; } 
}
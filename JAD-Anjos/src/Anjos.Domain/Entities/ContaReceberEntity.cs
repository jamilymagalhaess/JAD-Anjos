using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anjos.Domain.Entities;

public class ContaReceberEntity
{
    public ContaReceberEntity()
    {
        
    }

    [Key]
    public int Id { get; set; }
    public int VendaId { get; set; }
    public int QuantidadeParcelas { get; set; }
    public decimal Valor { get; set; }

    public virtual VendaEntity Venda { get; set; }
    public virtual ICollection<ParcelaEntity> Parcela { get; set; }

}

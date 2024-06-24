using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anjos.Domain.Entities;

public class ContaReceber
{
    public ContaReceber()
    {
        
    }

    [Key]
    public int Id { get; set; }
    public int QuantidadeParcelas { get; set; }
    public decimal Valor { get; set; }
    public int VendaId { get; set; }

    public virtual Venda Venda { get; set; }
    public virtual ICollection<Parcela> Parcela { get; set; }

}

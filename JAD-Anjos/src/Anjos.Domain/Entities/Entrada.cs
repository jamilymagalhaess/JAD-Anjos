using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anjos.Domain.Entities;

public class Entrada
{
    public Entrada()
    {
        
    }

    [Key]
    public int Id { get; set; }
    public decimal Valor { get; set; }

    public virtual ICollection<EntradaProduto> EntradaProduto { get; set; }
    public virtual ICollection<ContaPagar> ContaPagar { get; set; }
}

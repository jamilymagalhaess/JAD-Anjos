using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anjos.Domain.Entities;

public class EntradaEntity
{
    public EntradaEntity()
    {
        
    }

    [Key]
    public int Id { get; set; }
    public decimal Valor { get; set; }

    public virtual ICollection<EntradaProdutoEntity> EntradaProduto { get; set; }
    public virtual ICollection<ContaPagarEntity> ContaPagar { get; set; }
}

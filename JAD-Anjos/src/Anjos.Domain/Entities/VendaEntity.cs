using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anjos.Domain.Entities;

public class VendaEntity
{
    public VendaEntity()
    {
        
    }

    [Key]
    public int Id { get; set; }
    public decimal Valor { get; set; }
    public DateTime DataVenda { get; set; }
    public DateTime DataInclusao { get; set; }
    public string FormaPagamento { get; set; }

    public virtual ICollection<ContaReceberEntity> ContaReceber { get; set; }
    public virtual ICollection<VendaProdutoEntity> VendaProduto{ get; set; }

}
using System.ComponentModel.DataAnnotations;
using Anjos.Database.Repositories.Entity;

namespace Anjos.Domain.Entities;

public class Venda : IEntity
{
    public Venda()
    {
        
    }

    [Key]
    public int Id { get; set; }
    public decimal Valor { get; set; }
    public DateTime DataVenda { get; set; }
    public DateTime DataInclusao { get; set; }
    public string FormaPagamento { get; set; }

    public virtual ICollection<ContaReceber> ContaReceber { get; set; }
    public virtual ICollection<VendaProduto> VendaProduto{ get; set; }

}
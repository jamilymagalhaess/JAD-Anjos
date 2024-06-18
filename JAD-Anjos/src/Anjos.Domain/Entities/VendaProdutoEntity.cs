using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anjos.Domain.Entities;

public class VendaProdutoEntity
{
    public VendaProdutoEntity()
    {
        
    }

    [Key]
    public int Id { get; set; }
    public decimal Valor { get; set; }
    public int Quantidade { get; set; }
    public int VendaId { get; set; }
    public int ProdutoId { get; set; }

    [ForeignKey("VendaId")]
    public virtual VendaEntity Venda { get; set; }
    [ForeignKey("ProdutoId")]
    public virtual ProdutoEntity Produto { get; set; }

}
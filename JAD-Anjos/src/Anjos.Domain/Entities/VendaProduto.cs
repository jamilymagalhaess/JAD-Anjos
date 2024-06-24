using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anjos.Domain.Entities;

public class VendaProduto
{
    public VendaProduto()
    {
        
    }

    [Key]
    public int Id { get; set; }
    public decimal Valor { get; set; }
    public int Quantidade { get; set; }
    public int VendaId { get; set; }
    public int ProdutoId { get; set; }

    [ForeignKey("VendaId")]
    public virtual Venda Venda { get; set; }
    [ForeignKey("ProdutoId")]
    public virtual Produto Produto { get; set; }

}
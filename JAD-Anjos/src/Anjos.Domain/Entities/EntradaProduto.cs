using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anjos.Domain.Entities;

public class EntradaProduto
{
    public EntradaProduto()
    {
        
    }

    [Key]
    public int Id { get; set; }
    public int Quantidade { get; set; }
    public decimal Valor { get; set; }
    public DateTime DataEntrada { get; set; }
    public DateTime DataInclusao { get; set; }
    public int EntradaId { get; set; }
    public int ProdutoId { get; set; }

    [ForeignKey("EntradaId")]
    public virtual Entrada Entrada { get; set; }
    [ForeignKey("ProdutoId")]
    public virtual Produto Produto { get; set; }

}

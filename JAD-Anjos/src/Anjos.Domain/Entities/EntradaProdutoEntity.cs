using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anjos.Domain.Entities;

public class EntradaProdutoEntity
{
    public EntradaProdutoEntity()
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
    public virtual EntradaEntity Entrada { get; set; }
    [ForeignKey("ProdutoId")]
    public virtual ProdutoEntity Produto { get; set; }

}

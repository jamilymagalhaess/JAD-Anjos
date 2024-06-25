using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anjos.Domain.Entities;

public class Produto 
{
    [Key]
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public decimal Valor { get; set; }
    public int Quantidade { get; set; }
    public bool? ExibeNoSite { get; set; }

    [ForeignKey("CategoriaId")]
    public int CategoriaId { get; set; }

}
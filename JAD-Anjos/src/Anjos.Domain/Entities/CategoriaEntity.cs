using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anjos.Domain.Entities;

public class CategoriaEntity
{
    public CategoriaEntity()
    {
        
    }

    [Key]
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public virtual ICollection<ProdutoEntity> Produto { get; set; }

}

using System.ComponentModel.DataAnnotations;
using Anjos.Database.Repositories.Entity;

namespace Anjos.Domain.Entities;

public class Categoria
{
    public Categoria()
    {
        
    }

    [Key]
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }

    public virtual ICollection<Produto> Produto { get; set; }

}

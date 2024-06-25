using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Anjos.Domain.Entities
{
    public class Entrada
    {
        public Entrada()
        {
            EntradaProduto = new List<EntradaProduto?>();
            ContaPagar = new List<ContaPagar?>();
        }

        [Key]
        public int Id { get; set; }
        public decimal Valor { get; set; }

        public virtual ICollection<EntradaProduto?> EntradaProduto { get; set; }
        public virtual ICollection<ContaPagar?> ContaPagar { get; set; }
    }
}

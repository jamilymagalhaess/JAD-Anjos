using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Anjos.Domain.Entities
{
    public class Venda
    {
        [Key]
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataVenda { get; set; }
        public DateTime DataInclusao { get; set; }
        public string? FormaPagamento { get; set; }

        public virtual ICollection<ContaReceber?> ContaReceber { get; set; }
        public virtual ICollection<VendaProduto?> VendaProduto { get; set; } 
    }
}

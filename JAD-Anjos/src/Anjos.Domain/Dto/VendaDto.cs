using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anjos.Domain.Dto;

public class VendaDto
{
    public int Id { get; set; }
    public decimal Valor { get; set; }
    public DateTime DataVenda { get; set; }
    public DateTime DataInclusao { get; set; }
    public string? FormaPagamento { get; set; }
}

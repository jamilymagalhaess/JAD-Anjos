using System;

namespace Anjos.Domain.Dto;

public class ContaReceberDto
{
    public int Id { get; set; }
    public decimal Valor { get; set; }
    public int QuantidadeParcelas { get; set; }
    public int VendaId { get; set; }
}

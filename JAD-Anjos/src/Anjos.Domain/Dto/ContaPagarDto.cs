using System;

namespace Anjos.Domain.Dto;

public class ContaPagarDto
{
    public int Id { get; set; }
    public decimal Valor { get; set; }
    public int QuantidadeParcelas { get; set; }
    public int EntradaId { get; set; }
}

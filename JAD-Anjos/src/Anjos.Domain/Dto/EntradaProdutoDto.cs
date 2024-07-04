using System;

namespace Anjos.Domain.Dto;

public class EntradaProdutoDto
{
    public int Id { get; set; }
    public int Quantidade { get; set; }
    public decimal Valor { get; set; }
    public DateTime DataEntrada { get; set; }
    public int EntradaId { get; set; }
    public int ProdutoId { get; set; }
}

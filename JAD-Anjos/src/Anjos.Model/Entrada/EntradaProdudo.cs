﻿namespace Anjos.Model.Entities;

public class EntradaProduto
{
    public int Id { get; set; }
    public int EntradaId { get; set; }
    public int ProdutoId { get; set; }
    public int Quantidade { get; set; }
    public decimal Valor { get; set; }
    public DateTime DataEntrada { get; set; }
    public DateTime DataInclusao { get; set; }

}
﻿using System;

namespace Anjos.Domain.Dto;

public class ParcelaDto
{
    public int Id { get; set; }
    public int Tipo { get; set; }
    public int Numero { get; set; }
    public decimal Valor { get; set; }
    public decimal Juros { get; set; }
    public DateTime DataVencimento { get; set; }
    public int ContaPagarId { get; set; }
    public int ContaReceberId { get; set; }
}
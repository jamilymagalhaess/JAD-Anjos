﻿using Anjos.Domain.Entities;

namespace Anjos.Domain.Dto;

public class Paginacao
{
    public int Pagina { get; set; }
    public int Itens { get; set; }
    public int? Filtro { get; set; }
    public string? Ordenacao { get; set; }
    public string? DirecaoDaOrdenacao { get; set; }

}

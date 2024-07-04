using Anjos.Domain.Entities;
using Anjos.Domain.Dto;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Anjos.Application.Interfaces;
public interface ICategoriaService
{
    Task<Categoria> ObterByIdAsync(int id);
    Task<PaginacaoResultadoDto> ObterPaginadoComTotalAsync(PaginacaoDto dto);
    Task<Categoria> AdicionarCategoriaAsync(CategoriaDto categoriaDto);
    Task<Categoria> AtualizarCategoriaAsync(CategoriaDto categoriaDto);
    Task DeletarCategoriaAsync(int id);
}

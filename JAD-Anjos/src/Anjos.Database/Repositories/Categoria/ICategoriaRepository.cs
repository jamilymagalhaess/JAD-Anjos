using Anjos.Domain.Dto;
using Anjos.Database.Repositories.Base;
using CategoriaEntity = Anjos.Domain.Entities.Categoria;

public interface ICategoriaRepository : IRepository<CategoriaEntity>
{
    Task<CategoriaEntity> ObterByIdAsync(int id);
    Task<IEnumerable<CategoriaEntity>> ObterPaginadoAsync(PaginacaoDto dto);
    Task<int> ObterTotalCategoriasAsync(int? filtro);
    Task Atualizar(CategoriaEntity categoria);
    Task Deletar(CategoriaEntity categoria);
}

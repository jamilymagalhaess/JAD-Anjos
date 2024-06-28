using System.Linq.Expressions;

namespace Anjos.Database.Repositories.Base
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Adicionar(TEntity entidade);
        Task Remover(TEntity entidade);
        Task<IEnumerable<TEntity>> ObterPaginadoAsync(IQueryable<TEntity> query, int pagina, int itens);
        IQueryable<TEntity> AplicarOrdenacao(IQueryable<TEntity> query, string ordenacao, string direcaoDaOrdenacao, Dictionary<string, Expression<Func<TEntity, object>>> orderByMappings);
    }
}

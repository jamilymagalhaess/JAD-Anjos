namespace Anjos.Database.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task Adicionar(TEntity entidade);
        Task Remover(TEntity entidade);
    }
}

namespace DBContexts.V2.Contracts.Contracts
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        TEntity? GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Add(TEntity entity);
        void Update(TEntity entity);
        void SetContext(Type contextType);
        void Delete(TEntity entity);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
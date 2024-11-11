using DBContexts.V2.Contracts.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DbContexts.V2.DataAccessLayer.Repository
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        protected DbContext Context { get; private set; }
        protected IServiceProvider ServiceProvider { get; private set; }

        public Repository(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            Context = ServiceProvider.GetRequiredService<DbContext>();
        }

        public TEntity? GetById(int id)
        {
            return Set().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Set().ToList();
        }

        public void Add(TEntity entity)
        {
            Set().Add(entity);
        }

        public void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return Context.SaveChangesAsync(cancellationToken);
        }

        public void Delete(TEntity entity)
        {
            Set().Remove(entity);
        }

        protected DbSet<TEntity> Set()
        {
            return Context.Set<TEntity>();
        }

        public void SetContext(Type contextType)
        {
            Context = (DbContext)ServiceProvider.GetRequiredService(contextType);
        }
    }
}
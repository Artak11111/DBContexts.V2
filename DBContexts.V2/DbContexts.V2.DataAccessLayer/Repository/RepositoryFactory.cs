using DbContexts.V2.DataAccessLayer.Contexts;
using DBContexts.V2.Contracts.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace DbContexts.V2.DataAccessLayer.Repository
{
    public class RepositoryFactory : IRepositoryFactory
    {
        protected IServiceProvider ServiceProvider { get; }
        protected Dictionary<DatabaseType, Type> Mappings { get; } = new Dictionary<DatabaseType, Type>
        {
            { DatabaseType.Books, typeof(FirstDbContext) },
            { DatabaseType.Movies, typeof(SecondDbContext) },
        };

        public RepositoryFactory(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public IRepository<T> Get<T>(DatabaseType dbType) where T : class
        {
            var repository = ServiceProvider.GetRequiredService<IRepository<T>>();
            repository.SetContext(Mappings[dbType]);
            return repository;
        }
    };
}

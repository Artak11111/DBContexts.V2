using DBContexts.V2.Contracts.Contracts;
using DbContexts.V2.DataAccessLayer.Contexts;
using DbContexts.V2.DataAccessLayer.Repository;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace DbContexts.V2.DataAccessLayer.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FirstDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("FirstConnectionString")), ServiceLifetime.Transient);

            services.AddDbContext<SecondDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SecondConnectionString")), ServiceLifetime.Transient);

            services.AddScoped<IRepositoryFactory, RepositoryFactory>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        }
    }
}

namespace DBContexts.V2.Contracts.Contracts
{
    public interface IRepositoryFactory
    {
        IRepository<T> Get<T>(DatabaseType dbType = DatabaseType.Books)
            where T : class;
    }

    public enum DatabaseType
    {
        Books,
        Movies
    }
}
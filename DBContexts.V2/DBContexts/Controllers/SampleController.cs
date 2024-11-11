using DBContexts.V2.Contracts.Contracts;
using DBContexts.V2.Domain.Models;
using Microsoft.AspNetCore.Mvc;
namespace DBContexts.V2.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SampleController : ControllerBase
    {
        protected IRepository<Book> BookRepository { get; }

        protected IRepository<Movie> MovieRepository { get; }

        public SampleController(IRepositoryFactory repositoryFactory)
        {
            BookRepository = repositoryFactory.Get<Book>(DatabaseType.Books);
            MovieRepository = repositoryFactory.Get<Movie>(DatabaseType.Movies);
        }

        [HttpGet(Name = "get-books")]
        public async Task<IEnumerable<Book>> GetBooks()
        {
            var book = new Book
            {
                Name = "Book " + Guid.NewGuid()
            };

            BookRepository.Add(book);

            await BookRepository.SaveChangesAsync();

            return BookRepository.GetAll();
        }

        [HttpGet(Name = "get-movies")]
        public async Task<IEnumerable<Movie>> GetMovies()
        {
            var movie = new Movie
            {
                Name = "Movie " + Guid.NewGuid()
            };

            MovieRepository.Add(movie);

            await MovieRepository.SaveChangesAsync();

            return MovieRepository.GetAll();
        }
    }
}
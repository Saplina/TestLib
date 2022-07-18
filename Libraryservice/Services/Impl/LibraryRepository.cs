using Libraryservice.Models;

namespace Libraryservice.Services.Impl
{
    public class LibraryRepository : ILabraryRepositoryService
    {
        private readonly ILibraryDatabaseContextService _dbContext;
        private readonly ILogger<LibraryRepository> _logger;

        public LibraryRepository(ILibraryDatabaseContextService dbContext,
            ILogger<LibraryRepository> logger)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IList<Book> GetByTitle(string title)
        {
            try
            {
                return _dbContext.Books.Where(book =>
                    book.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Get books by title error.");
                return new List<Book>();
            }
        }

        public IList<Book> GetByAuthor(string authorName)
        {
            try
            {
                return _dbContext.Books.Where(book =>
                book.Authors.Where(author =>
                    author.Name.Contains(authorName, StringComparison.OrdinalIgnoreCase)).Count() > 0).ToList();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Get books by author error.");
                return new List<Book>();
            }
        }

        public IList<Book> GetByCategory(string category)
        {
            try
            {
                return _dbContext.Books.Where(book =>
                    book.Category.Contains(category, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Get books by category error.");
                return new List<Book>();
            }
        }

        public int? Add(Book item)
        {
            throw new NotImplementedException();
        }

        public int Delete(Book item)
        {
            throw new NotImplementedException();
        }

        public IList<Book> GetAll()
        {
            throw new NotImplementedException();
        }
       
        public Book GetById<TId>(TId id)
        {
            throw new NotImplementedException();
        }
      
        public int Update(Book item)
        {
            throw new NotImplementedException();
        }
    }
}

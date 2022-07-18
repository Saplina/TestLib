using Libraryservice.Models;

namespace Libraryservice.Services
{
    public interface ILabraryRepositoryService : IRepository<Book>
    {
        IList<Book> GetByTitle(string title);

        IList<Book> GetByAuthor(string authorName);

        IList<Book> GetByCategory(string category);

    }
}

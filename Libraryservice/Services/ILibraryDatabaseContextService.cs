using Libraryservice.Models;

namespace Libraryservice.Services
{
    public interface ILibraryDatabaseContextService
    {
        IList<Book> Books { get; }
    }
}
